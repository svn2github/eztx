using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
//Download by http://www.codefans.net
namespace MyProcessBar
{
    public partial class MyProcessBar : UserControl
    {
        public delegate void TaskHandler(ref float percentage);
        private Thread _monitorThread = null;
        private Thread _workerThread = null;
        private float _percentage = 0f;
        private MyProcessBarStatue _currentStatue = MyProcessBarStatue.UnStarted;
        private TaskHandler _task = null;
        public MyProcessBar()
        {
            InitializeComponent();
            this._monitorThread = new Thread(new ThreadStart(Monitor));//监听线程 只构造一次
        }
        /// <summary>
        /// 任务委托
        /// 多次对该属性赋值会造成不必要的浪费
        /// </summary>
        public TaskHandler Task
        {
            set
            {
                //任务线程 通过传入引用类型参数获得实时的进度变更 
                this._workerThread = new Thread(() => value(ref _percentage));
                this._task = value;
            }
        }

        /// <summary>
        /// 外部也可以实时获取当前任务进度
        /// </summary>
        public float Percentage
        {
            get
            {
                return this._percentage;
            }
        }
        /// <summary>
        /// 外部实时获取当前任务状态
        /// </summary>
        public MyProcessBarStatue CurrentStatue
        {
            get
            {
                return this._currentStatue;
            }
        }

        public void Run()
        {
            if (this._workerThread == null)
            {
                throw new NullReferenceException("Task委托不能为空！");
            }
            //初次启动 需要同时启动工作线程和监听线程
            if (this._currentStatue == MyProcessBarStatue.UnStarted)
            {
                _monitorThread.IsBackground = true;
                _monitorThread.Start();
                _workerThread.IsBackground = true;
                _workerThread.Start();
                this._currentStatue = MyProcessBarStatue.Running;
            }
            //被终止后第二次启动 只需要重启工作线程就可以 
            else if (this._currentStatue == MyProcessBarStatue.Aborted)
            {
                this._currentStatue = MyProcessBarStatue.Running;
                //若原工作线程已经终止 则重新初始化工作线程
                if (this._workerThread.ThreadState == ThreadState.Aborted)
                {
                    this._workerThread = null;
                    this._workerThread = new Thread(() => _task(ref _percentage));
                }
                _workerThread.IsBackground = true;
                _workerThread.Start();
            }
            else
            {
                throw new InvalidOperationException("已经开始的任务无法再次开始！");
            }
        }

        

        public void Stop()
        {
            if (_workerThread == null)
            {
                throw new NullReferenceException("Task委托不能为空！");
            }
            if (this._currentStatue == MyProcessBarStatue.Aborted)
            {
                throw new InvalidOperationException("已经终止的操作无法暂停！");
            }
            if (this._currentStatue != MyProcessBarStatue.Suspended)
            {
                _workerThread.Suspend();
                _monitorThread.Suspend();
                this._currentStatue = MyProcessBarStatue.Suspended;
            }
            
        }

        public void Resume()
        {
            if (_workerThread == null)
            {
                throw new NullReferenceException("Task委托不能为空！");
            }
            if (this._currentStatue == MyProcessBarStatue.Aborted)
            {
                throw new InvalidOperationException("已经终止的操作无法继续！");
            }
            if (this._currentStatue == MyProcessBarStatue.Suspended)
            {
                _monitorThread.Resume();
                _workerThread.Resume();
                this._currentStatue = MyProcessBarStatue.Running;
            }
            
        }

        public void Abort()
        {
            if (this._workerThread == null)
            {
                throw new NullReferenceException("Task委托不能为空！");
            }
            if (this._currentStatue != MyProcessBarStatue.Aborted)
            {
                //若之前为Suspended状态 则需要先Resume才可以终止工作线程
                this.Resume();
                _workerThread.Abort();
                this._currentStatue = MyProcessBarStatue.Aborted;
            }
        }

        private void Monitor()
        {
            //外层无限循环 监听标志变量的改变
            while (true)
            {
                //当UI调用Start方法时监听线程首次启动并设置标志变量为Running
                if (this._currentStatue == MyProcessBarStatue.Running)
                {
                    //在此循环中监听_percetage变量的改变情况 由于该变量作为引用参数传入Task委托 所以可以得到实时的进度
                    while (this._percentage <= 1f)
                    {
                        //调用Draw方法更新UI
                        using (var graphic = pictureBox1.CreateGraphics())
                        {
                            if (this.pictureBox1.InvokeRequired)
                            {
                                this.Invoke(new Action(() => Draw(this._percentage, graphic)));
                            }
                            else
                            {
                                this.Draw(this._percentage, graphic);
                            }

                            Thread.Sleep(10);//重绘间隔为10ms
                            //当发现标志变量改变为终止时跳出 回到最外层监听标志变量的循环
                            if (this._currentStatue == MyProcessBarStatue.Aborted)
                            {
                                this._percentage = 0f;//将百分比重置为0
                                if (this.pictureBox1.InvokeRequired)//将绘图区清空
                                {
                                    this.Invoke(new Action(() => this.Clear(graphic)));
                                }
                                else
                                {
                                    this.Clear(graphic);
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 如果要更改进度条显示的形式 则继承当前类 重写Draw方法
        /// </summary>
        /// <param name="percentage"></param>
        /// <param name="graphic"></param>
        protected virtual void Draw(float percentage,Graphics graphic)
        {
            graphic.FillRectangle(Brushes.Black, 0f, 0f, _percentage * pictureBox1.Width, pictureBox1.Height);
        }
        /// <summary>
        /// 若需要更改进度条默认颜色 背景 则继承当前类 重写Clear方法
        /// </summary>
        /// <param name="graphic"></param>
        private virtual void Clear(Graphics graphic)
        {
            graphic.Clear(Color.White);
        }
    }
    //进度条状态枚举
    public enum MyProcessBarStatue
    {
        UnStarted,
        Running,
        Suspended,
        Aborted
    }
}

<%@ page language="java" contentType="text/html; charset=utf-8"
	pageEncoding="utf-8"%>
<%@page import="com.breadth.dbp.DataBaseProvide"%>
<%@page import="com.breadth.dbp.util.DataTable"%>
<%@page import="com.breadth.dbp.util.DataRow"%>
<%@page import="java.io.File"%>
<%@page import="java.io.IOException"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
	</head>
	<body>

		<table>
			<%
				DataBaseProvide dbp = DataBaseProvide.getNewInstance();

				String sql = "select projectname,projectid,count(*) as a from doc group by projectid";

				int cc = 0;
				DataTable dt = dbp.executeQuery(sql, null);

				for (int i = 0; i < dt.size(); i++) {
					DataRow dr = dt.getRow(i);

					out.print("<tr>");
					out.print("<td>"+(i+1)+"</td>");
					out.print("<td><a href='b.jsp?pid="+dr.getString("projectid")+"' target='_blank'>"+dr.getString("projectname")+"</a></td>");
					out.print("<td>"+dr.getString("a")+"</td>");
					out.print("</tr>");
				}
			%>
		</table>
	</body>
</html>
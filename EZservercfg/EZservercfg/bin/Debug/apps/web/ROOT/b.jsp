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
				
				String pid = request.getParameter("pid");

				String sql = "select id,projectid,projectname,originalPath,thumbnailPath from doc where projectid='"+pid+"'";

				int cc = 0;
				DataTable dt = dbp.executeQuery(sql, null);

				for (int i = 0; i < dt.size(); i++) {
					DataRow dr = dt.getRow(i);

					String value = dt.getRow(i).getString("originalPath");
					String value2 = dt.getRow(i).getString("thumbnailPath");
					String a = value.replaceAll("original", "tiny");
					String b = value.replaceAll("original", "big");
					String c = value.replaceAll("original", "large");
					
					if((i)%5==0){
						out.print("<tr>");
					}
					
					show(out,dr.getString("id"),dr.getString("projectname"),b);
					
					if((i+1)%5==0){
						out.print("</tr>");
					}
				}
			%>


<%!private static void show(JspWriter out, String id,String pname, String path) {
		try {
			out.print("<td><img width='200' src='http://192.168.1.22:9900/" + path
					+ "' /></br>"+id+"&nbsp;&nbsp;"+pname+"</td>");
		} catch (IOException e) {
			e.printStackTrace();
		}
	}%>
		</table>
	</body>
</html>
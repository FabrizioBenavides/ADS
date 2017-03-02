<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="PopArticulos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.PopArticulos" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD html 4.0 transitional//EN">
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<% 
'====================================================================
' Page          : 
' Title         : 
' Description   : 
' Copyright     : 
' Company       : BENAVIDES
' Author        : J.Antonio Hernández Dávila
' Version       : 1.0
' Last Modified : 
'
'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
'====================================================================	
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
//<!--
		
			function window_onload() {
				<%= strLlenarArticulosComboBox() %>
				document.forms[0].action = "PopArticulos.aspx";
				return(true);
				}

		function cmdAgregar_onclick() 
		{
			var blnSelected = false;
			for (var intCounter = 0; intCounter < document.forms[0].elements["cboArticulos"].length; intCounter++) 
			{
				blnSelected = document.forms[0].elements["cboArticulos"].options[intCounter].selected;
				if (blnSelected == true) break;
			}
			if (blnSelected == true) 
			{
				document.forms[0].action += "?strCmd=Agregar";
				document.forms[0].submit();
			} 
			else 
			{
				alert("Por favor seleccione al menos un articulo.");
				document.forms[0].elements["cboArticulos"].focus();
				return(false);
			}
		}

		function cmdCerrar_onclick() 
		{
			document.forms[0].action += "?strCmd=Cerrar";
			document.forms[0].submit();
		}
		
		function ClosePopup(intValor,strNombre,intDepartamento)
		{
			opener.document.forms[0].elements['<%=Request.QueryString("strArticulo")%>'].value = intValor;
			opener.document.forms[0].elements['<%=Request.QueryString("strArticuloNombreId")%>'].value = strNombre;
			
			<% if Request.QueryString("strEvalJs")<>"" then %>
			eval("<%=Request.QueryString("strEvalJs")%>");
			<% end if %>		
			
			<% if Request.QueryString("strEvalJsClosePopup")<>"" then %>
			eval("<%=Request.QueryString("strEvalJsClosePopup")%>");
			<% end if %>	
			
			self.close();
			return(true);
		}

		function window_onunload() {
			<% if Request.QueryString("strEvalJs")<>"" then %>
			eval("<%=Request.QueryString("strEvalJs")%>");
			<% end if %>
		}

//-->
</script>
</HEAD>
<body language="javascript" onload="return window_onload()" bgcolor="#ffffff" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0" onUnload="return window_onunload()" >
<form name="frmPopArticulos" action="about:blank" method="post">
  <table height="258" cellspacing="0" cellpadding="0" width="100%" bgcolor="#ffffff" border="0">
    <tr> 
      <td class="tdlogopop" colspan="2" height="54"><script language="javascript">crearTablaHeaderPop()</script></td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td valign="top" width="99%" height="10">&nbsp;</td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td valign="top" height="30"><span class="txtitulo">Catalogo Antibioticos</span> 
        <div class="txcontenido" id="lblSelecciona" >Selecciona los Antibioticos 
          de la lista, al terminar,&nbsp;haz clic en el botón Agregar.</div>
        <div class="txcontenido" id="lblSinRegistros"  style="display:none">No 
          hay Antibioticos que coincidan con la busqueda.</div>
        <br> <br> <select id="cboArticulos" name="cboArticulos" size="10" multiple>
        </select> <span class="txcontenido"></span></td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td><input name="cmdAgregar" type="submit" class="boton" id="cmdAgregar" value="Agregar" onClick="return cmdAgregar_onclick()"> 
        <input name="cmdCerrar" type="submit" class="boton" id="cmdCerrar" value="Cerrar" onClick="return cmdCerrar_onclick()"> 
        <br> <br> </td>
    </tr>
  </table>
</form>
<%= strJavascriptWindowOnLoadCommands %> 
</body>
</HTML>

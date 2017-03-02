<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalAdministrarDevolucionArticuloAutorizado.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalAdministrarDevolucionArticuloAutorizado" codePage="1252" EnableSessionState="False" enableViewState="False" %>
<html>
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script id=clientEventHandlersJS language=javascript>
<!--
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";


function window_onload() {
  document.forms[0].action = "<%= strFormAction %>";
  document.forms[0].elements["txtProveedorId"].value = "<%=strProveedorId%>";
  
  <%= strJavascriptWindowOnLoadCommands %>
}

function cmdBuscar_onclick() {
   document.forms[0].action = "<%=strFormAction%>";
   document.forms[0].submit();
}

function cmdAgregar_onclick() {
  if (document.forms[0].elements["txtArchivo"].value.length < 1) {
    alert("Por favor especifique un valor para el campo \"Archivo\".");
    document.forms[0].elements["txtArchivo"].focus();
    return(false);
  }
  document.forms[0].action += "?strCmd=Agregar";
  return(true);
}

function cmdReemplazar_onclick() {
  if (document.forms[0].elements["txtArchivo"].value.length < 1) {
    alert("Por favor especifique un valor para el campo \"Archivo\".");
    document.forms[0].elements["txtArchivo"].focus();
    return(false);
  }
  document.forms[0].action += "?strCmd=Reemplazar";
  return(true);
}


function cmdEliminar_onclick() {
   if  (!confirm ('Esta seguro de eliminar la lista de articulos?') )  {
		return;
   }
   else {
       document.forms[0].action += "?strCmd=Eliminar";
   }
  
   return(true);
}

function cmdImprimir_onclick() {
  window.print();
}

function cmdCancelar_onclick() {
window.location.href = "SucursalHome.aspx";
}

//-->
</script>
</head>
<body language=javascript onload="return window_onload()">
<form name="frmMain" action="about:blank" method="post" runat=server ID="Form2">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : <a href="../_Manager/SucursalHome.aspx">Sucursal</a> 
        : Administración artiulos autorizados para devoluciones </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td class="tdgeneralcontent"><h1>Administración Articulos Autorizados para 
          Devoluciones</h1>
        <p>Actualizar o remplazar el listado de articulos autorizados para devoluciones 
          en sucursal.</p>
        <h2>Cargar listados de articulos</h2>
        <table width="60%"  border="0" cellspacing="0" cellpadding="0">
          <tr> 
            <td width="12%" class="tdtexttablebold">Proveedor:</td>
            <td class="tdpadleft5"><input class="field" id="txtbuscaCliente" type="text" autocomplete="off"  maxlength="35" size="45" name="txtProveedorId"  value='<%=Request("strProveedorId")%>'> 
              &nbsp;&nbsp;&nbsp; <input id="cmdBuscar" language="javascript" class="button" onclick="return cmdBuscar_onclick()" value=" Buscar" type="button" name="cmdBuscar"></td>
          </tr>
          <tr> 
            <td width="12%" class="tdtexttablebold">Archivo:</td>
            <td class="tdpadleft5"><input name="txtArchivo" id="txtArchivo" type="file" class="field" size="55" maxlength="55" runat="server"> 
              <br></td>
          </tr>
          <tr> 
            <td height="10" colspan="2"><img src="images/pixel.gif" width="1" height="10"></td>
          </tr>
          <tr> 
            <td height="10">&nbsp;</td>
            <td height="10" colspan="2" class="tdpadleft5"><input name="cmdAgregar" type="submit" class="button" id="cmdAgregar" value="Agregar" language=javascript onclick="return cmdAgregar_onclick()"> 
              &nbsp; <input name="cmdReemplazar" type="submit" class="button" id="cmdReemplazar" value="Reemplazar" language=javascript onclick="return cmdReemplazar_onclick()"> 
              &nbsp; <input name="cmdEliminar" type="submit" class="button" id="cmdEliminar" value="Eliminar" language=javascript onclick="return cmdEliminar_onclick()"></td>
          </tr>
        </table>
        <br> <table cellSpacing="0" cellPadding="0" width="100%" border="0">
          <tr> 
            <td align="right" width="90%"><input language="javascript" class="button" id="cmdRegresar" onclick="return cmdCancelar_onclick()"
						type="button" value="Regresar" name="cmdRegresar"> </td>
            <td align="right" width="10%"><input language="javascript" class="button" id="cmdImprimir" onclick="return cmdImprimir_onclick()"
						type="button" value="Imprimir" name="cmdImprimir"> </td>
          </tr>
        </table>
        <br> <%=  strGetRecordBrowserHTML() %> <br> </td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td><script language="JavaScript">crearTablaFooterCentral()</script></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
</script>
</form>
</body>
</html>

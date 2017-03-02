<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="PopConceptoPrenomina.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsPopConceptoPrenomina" codePage="28605" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%    '====================================================================
    ' Page          : PopConceptoPrenomina.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página donde se despliegan los conceptos de movimientos
	'					para la prenómina
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Armando Calzada Mezura
    ' Version       : 1.0
    ' Last Modified : Jueves, Octubre 23, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

function strRecordBrowserHTML() {
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}

function ClosePopup(intValor,strNombre, fltCantidad, strNombreId)
{
	opener.document.forms[0].elements['txtConcepto'].value = strNombreId;
	opener.document.forms[0].elements['txtConceptoNombre'].value = strNombre;
	opener.document.forms[0].elements['txtCantidadMaxima'].value = fltCantidad;
    opener.document.forms[0].elements['txtConceptoId'].value = intValor;
	self.close();
    return(true);
}

//-->
</script>
</head>
<body bgcolor="#FFFFFF" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<table width="100%" height="158" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
  <tr> 
    <td class="tdlogopop" colspan="2" height="54"><script language="javascript">crearTablaHeaderPop()</script></td>
  </tr>
  <tr> 
    <td width="2%">&nbsp;</td>
    <td width="99%" height="10" valign="top">&nbsp;</td>
  </tr>
  <tr> 
    <td width="2%">&nbsp;</td>
    <td height="30" valign="top"><span class="txtitulo">Seleccionar concepto</span><span class="txcontenido">Para 
      seleccionar un concepto, haga click en su nombre.<br>
      <br>
      </span> <span class="txcontenido">
      <script language="javascript">strRecordBrowserHTML();</script>
      </span></td>
  </tr>
  <tr> 
    <td width="2%">&nbsp;</td>
    <td><input name="cmdCerrar" type="button" class="boton" value="Cerrar ventana" onclick="return ClosePopup('','','','');"></td>
  </tr>
</table>
</body>
</html>

<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="SucursalReporteTablero.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalReporteTablero" codePage="28592" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : SucursalReporteTablero
    ' Title         : Administracion POS y BackOffice
    ' Description   : 
    ' Copyright     : 2013 All rights reserved.
    ' Company       : benavides
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : 31 Jul 2013
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link href="../static/css/menu.css" rel="stylesheet">
<link href="../static/css/menu2.css" rel="stylesheet">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/tools.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--
var strPaginaAyuda
strPaginaAyuda = "";


function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}
function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
	return(true);
}

function window_onload() {
  document.forms[0].action = "<%=strFormAction%>";   
}
function cmdVerRegion_onclick()
{
 iframeLayout.location = strUrlADSDoc() + "pdf/Tablero/R" + "<%=strRegionId%>"  + ".pdf";
 document.forms[0].elements['txtReporte'].value= "Reporte Tablero por Region";
} 
function cmdVerZona_onclick()
{
 iframeLayout.location = strUrlADSDoc() + "pdf/Tablero/Z" + "<%=strZonaId%>"  + ".pdf";
 document.forms[0].elements['txtReporte'].value= "Reporte Tablero por Zona";
} 
function cmdVerSucursal_onclick()
{
 iframeLayout.location = strUrlADSDoc() + "pdf/Tablero/" + "<%=strCentroLogisticoId%>" + ".pdf";
 document.forms[0].elements['txtReporte'].value= "Reporte Tablero por Sucursal";
} 

function cmdRegresar_onclick() {
    strRedireccionaPOSAdmin("Sucursal.aspx");
}


//-->
		</script>
</HEAD>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmSucursalReporteTablero" action="about:blank" method="post">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98" width="100%"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td valign="top" height="34" width="100%"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td width="100%"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgcolor="#ffffff"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><span class="txdmigaja">Está en : 
              </span><a href="javascript:strRedireccionaPOSAdmin('Sucursal.aspx')" class="txdmigaja"> 
              Sucursal</a>:<span class="txdmigaja">Reporte Tablero</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <script language="JavaScript">crearDatosSucursal()</script> 
                    <br> <table width="100%" border="0" cellpadding="0" cellspacing="0" height="60">
                      <tr> 
                        <td height="30" align="center"><img src="../static/images/imgIconPdf.gif" width="32" height="33" onclick="return cmdVerRegion_onclick()"> 
                        </td>
                        <td height="30" align="center"><img src="../static/images/imgIconPdf.gif" width="32" height="33" onclick="return cmdVerZona_onclick()"> 
                        </td>
                        <td height="30" align="center"><img src="../static/images/imgIconPdf.gif" width="32" height="33" onclick="return cmdVerSucursal_onclick()"> 
                        </td>
                      </tr>
                      <tr> 
                        <td height="20" align="center"><a onclick="return cmdVerRegion_onclick()" class="txsubtituloliga">Reporte 
                          por Region</a></td>
                        <td height="20" align="center"><a onclick="return cmdVerZona_onclick()" class="txsubtituloliga">Reporte 
                          por Zona</a></td>
                        <td height="20" align="center"><a onclick="return cmdVerSucursal_onclick()" class="txsubtituloliga">Reporte 
                          por Sucursal</a></td>
                      </tr>
                    </table>
                    <span class="txtitulo"> <br>
                    <input name="txtReporte" id="txtReporte" type="text" size="60" maxlength="80"  readonly tabindex="-1" class="campotablaresultadoblanco">
                    <br>
                    </span> <br> <table width="100%" border="0" cellpadding="0" cellspacing="0" height="460">
                      <tr> 
                        <td><iframe name="iframeLayout" id="iframeLayout" src="" frameborder="0" width="100%" scroll="yes"
																	height="100%" marginwidth="0" marginheight="0"></iframe> 
                        </td>
                      </tr>
                    </table>
                    <br> <br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()"> 
                    <br> </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"> <script language="javascript">strGeneraTablaAyuda('');</script> 
            </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <p> 
    <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
				</script>
  </p>
</form>
</body>
</HTML>

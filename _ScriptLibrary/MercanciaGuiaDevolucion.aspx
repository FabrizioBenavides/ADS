<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaGuiaDevolucion.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaGuiaDevolucion" codePage="28592" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaGuiaDevolucion.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   :  
    ' Copyright     : 2011 All rights reserved.
    ' Company       : 
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : 20 de Abril 2011 [JAHD]    Actualizacion por CADENA
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
function strCompaniaSucursal() {
	document.write(<%=intCompaniaId%> + " - " + <%=intSucursalId%>);
	return(true);
}
function strSucursalNombre() {
	document.write("&nbsp;"+"<%=strSucursalNombre%>");
	return(true);
}
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}
function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
	return(true);
}
function strSucursalNombre() {
	document.write("&nbsp;"+"<%=strSucursalNombre%>");
	return(true);
}
function window_onload() {
  document.forms[0].action = "<%=strFormAction%>"; 
  
}

function strImprimeGuia(strGuia) { 
   document.all.divBotones.style.display=''; 
   document.all.divBotones.style.visibility='visible'; 
   
   document.all.ifrDetalleDevo.style.display=''; 
   document.all.ifrDetalleDevo.style.visibility='visible'; 
   
   document.frmMercanciaGuiaDevolucion.target='ifrDetalleDevo';
   document.frmMercanciaGuiaDevolucion.action='MercanciaGuiaDevolucionifr.aspx?strCmd=Detalle&strArchivo=' + strGuia; 
   document.frmMercanciaGuiaDevolucion.submit();
   document.frmMercanciaGuiaDevolucion.target='';
}

function cmdImprimir_onclick() {
  document.ifrDetalleDevo.focus();
  window.print();
  
  document.all.ifrDetalleDevo.style.display='none'; 
  document.all.ifrDetalleDevo.style.visibility='hidden'; 

  document.all.divBotones.style.display='none'; 
  document.all.divBotones.style.visibility='hidden'; 
}

function cmdCerrar_onclick() {
  document.all.ifrDetalleDevo.style.display='none'; 
  document.all.ifrDetalleDevo.style.visibility='hidden'; 
   
  document.all.divBotones.style.display='none'; 
  document.all.divBotones.style.visibility='hidden';    
}

function cmdRegresar_onclick() {
     window.location="MercanciaSalidasDevoluciones.aspx";
}

//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmMercanciaGuiaDevolucion" action="about:blank" method="post">
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
              </span><a href="Mercancia.aspx" class="txdmigaja"> Mercancía</a><span class="txdmigaja"> 
              : <a href="MercanciaSalidas.aspx" class="txdmigaja"> Salidas</a><span class="txdmigaja"> 
              : </span><a href="MercanciaSalidasDevoluciones.aspx" class="txdmigaja"> 
              Devoluciones</a></span><span class="txdmigaja">: </span><span class="txdmigaja"> 
              </span><span class="txdmigaja">Impresión Guia Devolución</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <span class="txtitulo">Guia Devolución</span> <div id="divBotones" style="VISIBILITY: hidden;"> 
                      <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                        <tr> 
                          <td valign="top" align="right"><input name="cmdImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick()"> 
                            &nbsp;&nbsp; <input name="cmdCerrar" type="button" class="boton" value="Cerrar" onClick="return cmdCerrar_onclick()"></td>
                        </tr>
                      </table>
                    </div>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td valign="top"><iframe name="ifrDetalleDevo" id="ifrDetalleDevo"  frameborder="1" width="100%"  height="300" marginwidth="0" marginheight="0" style="display:none"></iframe></td>
                      </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td valign="top"><%=strListaArchivosGuias%></td>
                      </tr>
                    </table>
                    <br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()">	
                  </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
</script>
</form>
</body>
</HTML>

<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaPresupuestoCompras.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaPresupuestoCompras" codePage="28592"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaPresupuestoCompras.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para 
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Griselda Gómez Ponce
    ' Version       : 1.0
    ' Last Modified : Lunes, 17 De Noviembre, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--
var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";

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


function window_onLoad(){
   MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
   document.forms[0].action="<%=strFormAction()%>";
   
   //Iniciliza la lista de los meses
   <%=strGeneraListaMeses("cboMesConsulta")%>;
   
   //Muestra el mensaje al usuario si lo hay
   if ("<%=strMensaje%>"!=""){
      window.alert("<%=strMensaje%>");
      return false   
   }

}

function strNombreMes() {
	document.write("<%=strNombreMes%>");
	return(true);
}

function fltCuotaGastoValor() {
	document.write("<%=fltCuotaGastoValor%>");
	return(true);
}

function fltCompraPorDepartamentoImporteCompra() {
	document.write("<%=fltCompraPorDepartamentoImporteCompra%>");
	return(true);
}

function fltPorcentajeGasto() {
	document.write("<%=fltPorcentajeGasto%>");
	return(true);
}



function cmdConsultar_onclick() {
   if (document.forms[0].cboMesConsulta.value == "0") {
      alert("Seleccionar un mes");
      document.forms[0].cboMesConsulta.focus();
      return(false);
   }

   //Obtenemos los datos del presupuesto
   document.forms[0].action="<%=strFormAction%>?strCmd=Consultar";
   document.forms[0].submit();

}

function cmdImprimir_onclick() {
    printContent();
    return(true);
}

function cmdRegresar_onclick() {
  //Redireccionamos al home de Consulta de gasto
  strRedireccionaPOSAdmin('MercanciaEntradasConsultaGasto.aspx')  

}

function cmdVerComprasDepartamento_onclick() {
   //Redireccionamos a la página de compras por departamento
   window.location="MercanciaCompraPorDepartamento.aspx?cboMesConsulta=" + document.forms[0].cboMesConsulta.value;
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onLoad()">
<form action="about:blank" method="post" name="frmMercanciaPresupuestoCompras" >
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
            <td width="10" bgcolor="#FFFFFF"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Est&aacute; 
                en : </span><a href="Mercancia.aspx" class="txdmigaja">Mercanc&iacute;a</a><span class="txdmigaja"> 
                : <a href="javascript:strRedireccionaPOSAdmin('MercanciaEntradas.aspx')" class="txdmigaja">Entradas</a></span><span class="txdmigaja"> 
                : </span><span class="txdmigaja"></span><span class="txdmigaja"> 
                <a href="javascript:strRedireccionaPOSAdmin('MercanciaEntradasConsultaGasto.aspx')" class="txdmigaja">Consultar 
                gastos </a></span><span class="txdmigaja"> : </span><span class="txdmigaja">Presupuesto 
                de compras</span></div></td>
            <td width="182" class="tdfechahora"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p><span class="txtitulo">Presupuesto de compras</span><span class="txcontenido">Elija 
                      el mes que desea consultar.</span> 
                      <script language="JavaScript">crearDatosSucursal()</script>
                      <br>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td width="106" class="tdtittablas">Mes a consultar:</td>
                        <td width="477" valign="middle" class="tdpadleft5"><select name="cboMesConsulta" class="campotabla">
                          </select> </td>
                      </tr>
                    </table>
                    <br> <input name="cmdConsultar" type="button" class="boton" value="Consultar" onClick="return cmdConsultar_onclick()"> 
                    <br> <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle">Presupuesto 
                    de la sucursal para el mes</span> <br> <div id="ToPrintHtmContenido"> 
                      <table width="362" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                          <td width="252" class="tdtittablas">Presupuesto para 
                            el mes de 
                            <script language=javascript>strNombreMes()</script> 
                          </td>
                          <td width="110" class="tdconttablas" align=right><script language=javascript>fltCuotaGastoValor()</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Compras aplicadas a la fecha:</td>
                          <td class="tdconttablas" align=right><script language=javascript>fltCompraPorDepartamentoImporteCompra()</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Porcentaje de compras ejercido 
                            a la fecha:</td>
                          <td align="right" valign="top" class="tdconttablas"><script language=javascript>fltPorcentajeGasto()</script> 
                          </td>
                        </tr>
                      </table>
                    </div>
                    <br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()"> 
                    &nbsp;&nbsp;&nbsp; <input name="cmdImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick()"> 
                    &nbsp;&nbsp;&nbsp; <input name="cmdVerComprasDepartamento" type="button" class="boton" value="Ver compras por departamento" onClick="return cmdVerComprasDepartamento_onclick()"> 
                    <br> <p><br>
                  </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"> <script language="javascript">strGeneraTablaAyuda('');</script>	
            </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
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
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</html>

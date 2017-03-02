<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaDetalleEnvioTransferencias.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaDetalleEnvioTransferencias" codePage="28592"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaDetalleEnvioTransferencias.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para 
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Griselda Gómez Ponce
    ' Version       : 1.0
    ' Last Modified : Day, Month Day, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link href="../static/css/menu.css" rel=stylesheet >
<link href="../static/css/menu2.css" rel=stylesheet >
<link href="../static/css/estilo.css" rel=stylesheet >
<script language=JavaScript src="../static/scripts/Tools.js"></script>
<script language=JavaScript src="../static/scripts/menu.js"></script>
<script language=JavaScript src="../static/scripts/menu_items.js"></script>
<script language=JavaScript src="../static/scripts/menu_items2.js"></script>
<script language=JavaScript src="../static/scripts/menu_tpl.js"></script>
<script language=JavaScript src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language=JavaScript id=clientEventHandlersJS>
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

function frmMercanciaDetalleEnvioTransferencias_onsubmit() {
  valida=true;
	return(valida);
}

function window_onLoad(){
   MM_preloadImages('../static/images/bsalir_on.gif');
   document.forms[0].action ="<%=strFormAction%>";
}

function intEstadoTransferenciaFolio() {
	document.write("<%=intEstadoTransferenciaFolio%>");
	return(true);
}

function intTransferenciaNumeroOrden() {
	document.write("<%=intTransferenciaNumeroOrden%>");
	return(true);
}

function dtmTransferenciaRegistro() {
	document.write("<%=dtmTransferenciaRegistro%>");
	return(true);
}

function dtmEstadoTransferenciaRegistro() {
	document.write("<%=dtmEstadoTransferenciaRegistro%>");
	return(true);
}

function strMotivoTransferencia() {
	document.write("<%=strMotivoTransferencia%>");
	return(true);
}

function strSucursalDestino() {
	document.write("<%=strSucursalDestino%>");
	return(true);
}

function strRecordBrowserHTML(){  
     document.write("<%=strRecordBrowserHTML%>");   
}


function cmdRegresar_onclick() {
   document.location = 'MercanciaSalidas.aspx'; 

}

function cmdImprimir_onclick() {
  if (window.print) {
        document.ifrPageToPrint.document.all.ToPrintTxtMigaja.innerHTML=document.all.ToPrintTxtMigaja.innerText;
        document.ifrPageToPrint.document.all.ToPrintTxtFecha.innerHTML=document.all.ToPrintTxtFecha.innerText;
        document.ifrPageToPrint.document.all.ToPrintTxtSucursal.innerHTML=document.all.ToPrintTxtSucursal.innerText;
        document.ifrPageToPrint.document.all.ToPrintHtmContenido.innerHTML=document.all.ToPrintHtmContenido.innerHTML;
        
        //Mostrar Tabla de firmas
        document.ifrPageToPrint.document.all.divFirmasUp.style.display='';
        document.ifrPageToPrint.document.all.divFirmasDn.style.display='';
         
        
        document.ifrPageToPrint.focus();
        window.print();        
    } else {
        alert("Tu navegador no soporta la función: Print.")
    }
  
  return(true);
}

function cmdSalir_onclick() {  
  document.location = 'MercanciaSalidasTransferenciasOtraSucursal.aspx';
   

}

//-->
</script>
</head>
<body leftmargin=0 topmargin=0 onLoad="" marginheight="0" marginwidth="0" >
<form name=frmMercanciaDetalleEnvioTransferencias onSubmit="return frmMercanciaDetalleEnvioTransferencias_onsubmit()" action=about:blank method=post>
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
            <td width=10 bgcolor=#ffffff><img height=8 src="../static/images/pixel.gif" width=10 ></td>
            <td class=tdmigaja width=583> <div id=ToPrintTxtMigaja><span class=txdmigaja 
            >Está en : </span><a class=txdmigaja href="Mercancia.aspx" >Mercancía</a><span class="txdmigaja"> 
                : <a class=txdmigaja href="MercanciaSalidas.aspx" >Salidas</a> 
                : </span><span class=txdmigaja><a class=txdmigaja href="MercanciaSalidasTransferenciasOtraSucursal.aspx" >Transferencias 
                a otra sucursal</a> : </span><span class="txdmigaja"></span><span class="txdmigaja"></span><span class="txdmigaja">Detalle 
                de la transferencia archivada</span></div></td>
            <td class=tdfechahora width=182> <script language=javascript>strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width=10>&nbsp;</td>
            <td class=tdtablacont valign=top width=583><span class=txtitulo>Detalle 
              de envío archivado</span><span 
            class=txcontenido>La siguiente tabla contiene los detalles del envío 
              histórico que seleccionó.</span> <br> <div id="ToPrintHtmContenido"><span class=txsubtitulo><img height=11 src="../static/images/bullet_subtitulos.gif" width=17 > 
                Detalle de la transferencia</span> 
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                  <tr> 
                    <td class=tdtittablas width=154>No. de folio:</td>
                    <td class=tdconttablas width=429> <script language=javascript>intEstadoTransferenciaFolio()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class=tdtittablas>No. de orden:</td>
                    <td class=tdconttablas> <script language=javascript>intTransferenciaNumeroOrden()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class=tdtittablas>Fecha de la orden:</td>
                    <td class=tdconttablas> <script language=javascript>dtmTransferenciaRegistro()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class=tdtittablas>Fecha de confirmación:</td>
                    <td class=tdconttablas valign=top> <script language=javascript>dtmEstadoTransferenciaRegistro()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class=tdtittablas>Motivo de transferencia:</td>
                    <td class=tdconttablas> <script language=javascript>strMotivoTransferencia()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class=tdtittablas>Sucursal destino:</td>
                    <td class=tdconttablas> <script language=javascript>strSucursalDestino()</script> 
                    </td>
                  </tr>
                </table>
                <br>
                <script language=javascript>strRecordBrowserHTML()</script>
                <table id="divFirmasUp" style="display:none">
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>_________________</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>_________________</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>_________________</td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" align="center">&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="tdtittablas" align="center">Nombre y Firma</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="tdtittablas" align="center">&nbsp;</td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" align="center">Gerencia que Surte</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="tdtittablas" align="center">Empleado que Recibe</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="tdtittablas" align="center">Gerencia que Recibe</td>
                  </tr>
                </table>
                <table  id="divFirmasDn" style="display:none">
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas"> * Este documento no será válido sin 
                      el nombre y firma de autorización del representante del 
                      proveedor.* </td>
                  </tr>
                </table>
              </div>
              <!--CERRAMOS div id=ToPrintHtmContenido-->
              <br> <input class=boton type=button value=Regresar name=cmdSalir onClick="return cmdSalir_onclick()"> 
              &nbsp;&nbsp;&nbsp; <input class=boton type=button value=Imprimir name=cmdImprimir onClick="return cmdImprimir_onclick()"> 
              &nbsp;&nbsp;&nbsp; <input class=boton onClick="return cmdRegresar_onclick()" type=button value="Otro envío" name=cmdRegresar> 
              <br> <br> </td>
            <td class=tdcolumnader valign=top width=182 rowspan=2 
          >&nbsp;</td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language=JavaScript>
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
</script>
</form>
<iframe name=ifrPageToPrint src="../static/PageToPrint.htm" width=0 
height=0></iframe>
</body>
</html>

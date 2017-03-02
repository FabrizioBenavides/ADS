<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaPedidoVentaCatalogoDetalle.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaPedidoVentaCatalogoDetalle" codePage="28592" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : MercanciaPedidoVentaCatalogoDetalle.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Consultar detalle pedido capturado
    ' Copyright     : 2012 All rights reserved.
    ' Company       : Farmacias Benavides
    ' Author        : [JAHD] 
    ' Version       : 1.0
    ' Last Modified : 
    '                 31 de Octubre 2012 [JAHD] 
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
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--
function strHrefMigaja1(){
	document.location.href='Mercancia.aspx';
}
function strHrefMigaja2(){
	document.location.href='MercanciaPedido.aspx';
}
function strHrefMigaja3(){
	document.location.href='MercanciaPedidoVentaCatalogo.aspx';
}
function strHrefMigaja4(){
    strPaginapadre = "<%= strPaginapadre %>";
    
    if (strPaginapadre=="Captura") {
	    document.location.href='MercanciaPedidoVentaCatalogoCaptura.aspx';        
    } 
    else {
        document.location.href='MercanciaPedidoVentaCatalogoConsultar.aspx';
	}
}

function strTituloMigaja1(){
	document.write("Mercancía");
}
function strTituloMigaja2(){
	document.write("Pedidos");
}
function strTituloMigaja3(){
	document.write("Pedido Venta Catalogo");
}
function strTituloMigaja4(){    
    strPaginapadre = "<%= strPaginapadre %>";
    
    if (strPaginapadre=="Captura") {
	   document.write("Capturar Pedido");        
    } 
    else {
       document.write("Consultar Pedidos Capturados");
	}
	 
}
function strTituloPrincipalDePagina() {
	document.write("Detalle");
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}

function cmdRegresar_onclick() {    
    strPaginapadre = "<%= strPaginapadre %>";
    
    if (strPaginapadre=="Captura") {
	     window.location='MercanciaPedidoVentaCatalogoCaptura.aspx';         
    } 
    else {
         window.location='MercanciaPedidoVentaCatalogoConsultar.aspx';
	}   
}

function cmdImprimir_onclick() {
  document.ifrPageToPrint.document.all.divContenido.innerHTML = document.all.divImpresionHTML.innerHTML;        
  document.ifrPageToPrint.focus();
  window.print(); 
  return(true);
}

function window_onload() {
  document.forms[0].action = "<%=strFormAction%>";   
}

//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmMercanciaPedidoVentaCatalogoDetalle.aspx" action="about:blank"
			method="post">
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
              </span> <span class="txdmigaja"> <a class="txdmigaja" href="javascript:strHrefMigaja1();"> 
              <script language="javascript">strTituloMigaja1()</script>
              </a> : <a class="txdmigaja" href="javascript:strHrefMigaja2();"> 
              <script language="javascript">strTituloMigaja2()</script>
              </a> : <a class="txdmigaja" href="javascript:strHrefMigaja3();"> 
              <script language="javascript">strTituloMigaja3()</script>
              </a> : <a class="txdmigaja" href="javascript:strHrefMigaja4();"> 
              <script language="javascript">strTituloMigaja4()</script>
              </a> : 
              <script language="javascript">strTituloPrincipalDePagina()</script>
              </span> </td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><br> <script language="JavaScript">crearDatosSucursal()</script> 
              <br> <table width="99%" cellSpacing="0" cellPadding="0" border="0">
                <tr> 
                  <td class="txsubtitulo" vAlign="middle">Pedido Registrado con 
                    Folio: <%=intPedidoVentaCatalogoFolio%> </td>
                </tr>
              </table>
              <table class="tdenvolventetablas" width="99%">
                <tr> 
                  <td class="tdtittablas3" align="left" width="20%">Fecha Registro</td>
                  <td class="tdtittablas3" align="left" width="80%">Cliente</td>
                </tr>
                <tr> 
                  <td class="campotablaresultadoenvolventeazul" align="left" width="20%"><%=strPedidoVentaCatalogoRegistro%></td>
                  <td class="campotablaresultadoenvolventeazul" align="left" width="80%"><%=strClienteRFC%> 
                    - <%=strPedidoVentaCatalogoClienteRazonSocial%> </td>
                </tr>
              </table>
              <br> <table class="tdenvolventetablas" width="99%">
                <tr> 
                  <td class="tdtittablas3" align="left" width="20%">DIRECCION:</td>
                  <td class="campotablaresultadoenvolventeazul" align="left" width="80%"><%=strPedidoVentaCatalogoDatoEntregaCalle%> 
                    <%=strPedidoVentaCatalogoDatoEntregaNoExterior%> <%=strPedidoVentaCatalogoDatoEntregaNoInterior%> 
                    <%=strPedidoVentaCatalogoDatoEntregaColonia%></td>
                </tr>
                <tr> 
                  <td class="tdtittablas3" align="left" width="20%">CIUDAD:</td>
                  <td class="campotablaresultadoenvolventeazul" align="left" width="80%"><%=strPedidoVentaCatalogoDatoEntregaCiudad%></td>
                </tr>
                <tr> 
                  <td class="tdtittablas3" align="left" width="20%">ESTADO:</td>
                  <td class="campotablaresultadoenvolventeazul" align="left" width="80%"><%=strPedidoVentaCatalogoDatoEntregaEstado%></td>
                </tr>
                <tr> 
                  <td class="tdtittablas3" align="left" width="20%">C.P.:</td>
                  <td class="campotablaresultadoenvolventeazul" align="left" width="80%"><%=strPedidoVentaCatalogoDatoEntregaCodigoPostal%></td>
                </tr>
                <tr> 
                  <td class="tdtittablas3" align="left" width="20%">TELEFONO:</td>
                  <td class="campotablaresultadoenvolventeazul" align="left" width="80%"><%=strPedidoVentaCatalogoDatoEntregaTelefono%></td>
                </tr>
                <tr> 
                  <td class="tdtittablas3" align="left" width="20%">CEL/TEL ADICIONAL:</td>
                  <td class="campotablaresultadoenvolventeazul" align="left" width="80%"><%=strPedidoVentaCatalogoDatoEntregaMovil%></td>
                </tr>
                <tr> 
                  <td class="tdtittablas3" align="left" width="20%">E-MAIL:</td>
                  <td class="campotablaresultadoenvolventeazul" align="left" width="80%"><%=strPedidoVentaCatalogoDatoEntregaEMail%></td>
                </tr>
                <tr> 
                  <td class="tdtittablas3" align="left" width="20%">OBSERVACIONES:</td>
                  <td class="campotablaresultadoenvolventeazul" align="left" width="80%"><%=strPedidoVentaCatalogoDatoEntregaObservaciones%></td>
                </tr>
              </table>
              <br> <table cellSpacing="0" cellPadding="0" border="0" width="99%">
                <tr> 
                  <td> <%=strDetalleCompra%> <div id="divImpresionHTML" style="DISPLAY:none"><%=strImpresionCompra%> 
                      <br>
                    </div>
                    <br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()"> 
                    &nbsp; <input name="cmdImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick()"> 
                    <br> <br></td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          </tr>
        </table></td>
    </tr>
    <tr> 
      <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
    </tr>
  </table></TD></TR></TABLE>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
			</script>
</form>
<iframe name="ifrPageToPrint" src="ifrPaginaenBlanco.aspx" width="0" height="0"></iframe>
</body>
</HTML>

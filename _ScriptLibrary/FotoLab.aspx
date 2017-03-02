<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="FotoLab.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsFotoLab" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%  '====================================================================
    ' Page          : FotoLab.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página que muestra el menu principal de Entradas de Mercancias
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Jorge Tamez Sánchez
    ' Version       : 1.0
    ' Last Modified : Miercoles, Febrero 11, 2004
    '====================================================================
%>
<html>
<head>
<title>Benavides : Administrador de Puntos de Venta</title>
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/tools.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--
function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}

function window_onload() {
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
    document.forms[0].action = "<%=strFormAction%>";
    return(true);
}

function strCompaniaSucursal(){
	document.write(<%=intCompaniaId%> + " - " + <%=intSucursalId%>);
	return(true);
}
function strSucursalNombre() {
	document.write("<%=strSucursalNombre%>");
	return(true);
}
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}
function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
}
//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaEntradas">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td><table width="780" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td width="78" class="tdnodesucursal"><script language="JavaScript">strCompaniaSucursal()</script>
            </td>
            <td width="522" class="tdnombresucursal"><script language="javascript">strSucursalNombre()</script>
            </td>
            <td width="170" class="tdbotonestop"><a href="javascript:cmdSalirImg_onclick()" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image1','','../static/images/bsalir_on.gif',1)"><img src="../static/images/bsalir_off.gif" alt="salir" name="Image1" width="65" height="19" border="0"></a><a href="#" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image2','','../static/images/bayuda_on.gif',1)"><img src="../static/images/bayuda_off.gif" alt="ayuda" name="Image2" width="65" height="19" border="0"></a></td>
          </tr>
        </table>
      </td>
    </tr>
    <tr>
      <td><table width="780" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td width="520" rowspan="2" class="tdlogo"><img src="../static/images/logo.gif" width="255" height="51"></td>
            <td width="90" height="26">&nbsp;</td>
            <td width="170" class="tdnombreusuario"><script language="javascript">strUsuarioNombre()</script>
            </td>
          </tr>
          <tr>
            <td width="90" height="51" align="right" class="tdbusqueda">&nbsp;</td>
            <td width="170" valign="middle" class="tdbusquedacampo">&nbsp; </td>
          </tr>
        </table>
      </td>
    </tr>
    <tr>
      <td height="34"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr>
      <td><table width="780" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td width="10" bgcolor="#ffffff"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><span class="txdmigaja">Está en
                : </span><a href="javascript:strRedireccionaPOSAdmin('Sucursal.aspx');" class="txdmigaja">Sucursal</a> : <a href="javascript:strRedireccionaPOSAdmin('SucursalEmpleados.aspx');" class="txdmigaja">Empleados</a><span class="txdmigaja"> :
                Procesar prenómina</span></td>
            <td width="187" class="tdfechahora"><script language="JavaScript">strGetCustomDateTime()</script>
            </td>
          </tr>
          <tr>
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont">
              <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td colspan="3"> <span class="txtitulo">Empleados</span></td>
                </tr>
                <tr>
                  <td width="49%"><a href="FotoLabEmpleadosAdministrar.aspx" class="txsubtituloliga">Asignar
                      Rolles </a></td>
                  <td width="2%">&nbsp;</td>
                  <td width="49%">&nbsp;</td>
                </tr>
                <tr>
                  <td width="49%" class="tdcontenidoliga">Desde aqu&iacute; puede
                    ver los datos del empleado, asignarlo, desasignarlo y modificar
                    su contrase&ntilde;a.</td>
                  <td width="2%">&nbsp;</td>
                  <td width="49%" class="tdcontenidoliga">&nbsp;</td>
                </tr>
                <tr>
                  <td align="right">&nbsp;</td>
                  <td align="left">&nbsp;</td>
                  <td align="left">&nbsp;</td>
                </tr>
                <tr>
                  <td colspan="3"> <span class="txtitulo">Procesar prenómina</span></td>
                </tr>
                <tr>
                  <td width="49%"><a href="SucursalCapturarPrenomina.aspx" class="txsubtituloliga">Capturar
                      prenómina </a></td>
                  <td width="2%" rowspan="4">&nbsp;</td>
                  <td width="49%"><a href="SucursalConsultarComisionesEmpleado.aspx" class="txsubtituloliga">Consultar
                      comisiones por empleado</a></td>
                </tr>
                <tr>
                  <td width="49%" class="tdcontenidoliga">Capturar cada periodo
                    de pago, para los empleados, los movimientos que deben considerarse
                    para calcular su pago, tanto a favor (horas extra, primas
                    dominicales) como en contra (faltas).</td>
                  <td width="49%" class="tdcontenidoliga">Consultar, para todos
                    los empleados de la sucursal, las comisiones que se incluirán
                    en su pago dentro del periodo actual.</td>
                </tr>
                <tr>
                  <td><a href="SucursalConsultarCierrePrenomina.aspx" class="txsubtituloliga">Consultar
                      cierre de prenómina</a></td>
                  <td>&nbsp;</td>
                </tr>
                <tr>
                  <td class="tdcontenidoliga">Consultar cuáles serán los días
                    de cierre, así como el periodo de pago cubierto, para asegurarse
                    de cerrar a tiempo el envío de la prenómina.</td>
                  <td class="tdcontenidoliga">&nbsp;</td>
                </tr>
                <tr>
                  <td align="right">&nbsp;</td>
                  <td align="left">&nbsp;</td>
                  <td align="left">&nbsp;</td>
                </tr>
                <tr>
                  <td colspan="3"> <span class="txtitulo">Compras Directas</span></td>
                </tr>
                <tr>
                  <td><a href="MercanciaCapturarCompraDirecta.aspx" class="txsubtituloliga">Capturar
                      compra directa</a></td>
                  <td width="2%" rowspan="2">&nbsp;</td>
                  <td><a href="MercanciaConsultaComprasDirectas.aspx" class="txsubtituloliga">Consultar
                      registro de compras directas</a></td>
                  <td width="0%">&nbsp;</td>
                <tr>
                  <td width="49%" class="tdcontenidoliga">Capturar los productos
                    comprendidos en una compra directa.</td>
                  <td width="49%" class="tdcontenidoliga">Consultar el registro
                    histórica de compras directas vía sus notas de entrada.</td>
                </tr>
                <td align="right">&nbsp;</td>
                  <td align="left">&nbsp;</td>
                  <td align="left">&nbsp;</td>
                <tr>
                  <td colspan="3"> <span class="txtitulo">Recepción de mercancía</span></td>
                </tr>
                <tr>
                  <td> <a href="MercanciaConfirmarRemisionElectronica.aspx" class="txsubtituloliga">Remisión
                      electrónica</a></td>
                  <td width="2%" rowspan="4">&nbsp;</td>
                  <td><a href="MercanciaConfirmarFacturaElectronica.aspx" class="txsubtituloliga">Confirmar
                      factura electrónica</a></td>
                <tr>
                  <td width="49%" class="tdcontenidoliga">Confirmar los envíos
                    que le hacen de los almacenes, y capturar las excepciones
                    que puedan surgir.</td>
                  <td width="49%" class="tdcontenidoliga">Confirmar las entregas
                    de proveedores y capturar las excepciones que puedan surgir.</td>
                </tr>
                <tr>
                  <td width="49%"><a href="MercanciaConsultarFacturaRemision.aspx" class="txsubtituloliga">Consultar
                      archivo de facturas y remisiones</a></td>
                  <td>&nbsp;</td>
                </tr>
                <tr>
                  <td width="49%" class="tdcontenidoliga">Examinar el registro
                    histórico de facturas y remisiones confirmadas.</td>
                  <td width="49%" class="tdcontenidoliga">&nbsp;</td>
                </tr>
                <tr>
                  <td><a href="MercanciaCapturarFacturaManual.aspx" class="txsubtituloliga"> Captura
                      de Facturas y Remisiones Manualmente</a></td>
                  <td>&nbsp;</td>
                  <td><a href="MercanciaConsultarFacturaRemisionManual.aspx" class="txsubtituloliga"> Consulta
                      de Facturas y Remisiones Manualmente</a></td>
                </tr>
                <tr>
                  <td width="49%" class="tdcontenidoliga">Se realiza la captura
                    manual de facturas y remisiones, cuando estas no se encuentren
                    disponibles para confirmar.</td>
                  <td>&nbsp;</td>
                  <td width="49%" class="tdcontenidoliga">Se realiza consulta
                    de las facturas y remisiones capturadas manualmente, permite
                    verificar el status actual del documento y la opci&oacute;n
                    de imprimir el contrarecibo.</td>
                </tr>
              </table>
            <td width="187" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          <tr>
            <!-- inicio compras directas-->
            <!-- fin -->
            <td colspan="2" class="tdbottom">Sistema Administrador de Puntos
              de Venta - 2003 Farmacias Benavides</td>
          </tr>
        </table>
      </td>
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
</html>

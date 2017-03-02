<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FotoLabEmpleadosAdministrar.aspx.vb" Inherits="com.isocraft.backbone.ccentral.FotoLabEmpleadosAdministrar"%>
<HTML>
<HEAD>
<title>Benavides : Administrador de Puntos de Venta</title>
<%  '====================================================================
    ' Page          : FotoLabEmpleadosAdministrar.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página donde se administran a los Empleados de la Sucursal
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Benavides S.A. de C.V.
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Viernes, 03 Diciembre 2004
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script id="clientEventHandlersJS" language="javascript">
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
	EscribirMensajeError();
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
	document.forms[0].action = "<%=strFormAction%>";
	return(true);
}

function strCompaniaSucursal() {
   document.write(<%=intCompaniaId%>+" - "+<%=intSucursalId%>);
}

function strSucursalNombre(){
   document.write("<%=strSucursalNombre%>");
   return(true);
}

function strUsuarioNombre() {
   document.write("<%=strUsuarioNombre%>");
   return(true);
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}

function strRecordBrowserHTML(){
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}

function cmdRegresar_onclick() {
	document.location = "FotoLab.aspx";
   return(true);
}

function cmdImprimir_onclick() {
   printContent();
   return(true);
}

function EscribirMensajeError(){
  var intMensajeError = <%=intMensajeError%>;
  var strEstadoOperativo = "<%=strEstadoOperativo%>";
  var strMensaje = "";
  
    if (strEstadoOperativo.length > 1) {
        var strUltimaLetra = strEstadoOperativo.charAt(strEstadoOperativo.length - 1);
        strUltimaLetra = strUltimaLetra.toUpperCase();           
       }       
     
  if (strUltimaLetra == 'A'){
   strMensaje = "El empleado tiene " + strEstadoOperativo + " una caja";       
  }
  
  if (strUltimaLetra == 'O') {
    strMensaje = "El empleado esta " + strEstadoOperativo + " en una caja";
  }
  
   if (intMensajeError == 1) {
     alert(strMensaje);
  }      
}  
//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmFotoLabEmpleadosAdministrar">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td><div id="ToPrintTxtSucursal">
          <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
              <td width="78" class="tdnodesucursal"><script language="javascript">strCompaniaSucursal()</script>
              </td>
              <td width="522" class="tdnombresucursal"><script language="javascript">strSucursalNombre()</script>
              </td>
              <td width="170" class="tdbotonestop"><a href="javascript:cmdSalirImg_onclick()" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image1','','../static/images/bsalir_on.gif',1)"><img src="../static/images/bsalir_off.gif" alt="salir" name="Image1" width="65" height="19"
												border="0"></a><a href="#" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image2','','../static/images/bayuda_on.gif',1)"><img src="../static/images/bayuda_off.gif" alt="ayuda" name="Image2" width="65" height="19"
												border="0"></a></td>
            </tr>
          </table>
        </div>
      </td>
    </tr>
    <tr>
      <td><table width="780" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td width="520" rowspan="2" class="tdlogo"><img src="../static/images/logo.gif" alt="Farmacias Benavides" width="255" height="51"></td>
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
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Está
                  en :</span><span class="txdmigaja"> <a href="FotoLab.aspx" class="txdmigaja">Sucursal</a> : <a href="FotoLab.aspx" class="txdmigaja">Empleados</a> :
                  Administrar roles del personal</span></div>
            </td>
            <td width="187" class="tdfechahora"><div id="ToPrintTxtFecha">
                <script language="javascript">strGetCustomDateTime()</script>
              </div>
            </td>
          </tr>
          <tr>
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="583" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="100%" colspan="3" class="tdtablacont">
                    <p><span class="txtitulo">Administrar roles del personal </span>
                    <p><span class="txcontenido">Desde aquí puede asignar / desasignar
                        el rol al empleado. Para asignar un rol a un empleado
                        que no lo tiene, haga clic en "Editar" y asígnele el
                        rol. Para borrar el rol, haga clic en "Desasignar".</span> <br>
                    <div id="ToPrintHtmContenido">
                      <script language="javascript">strRecordBrowserHTML()</script>
                    </div>
                    <br>
                    <input name="cmdRegresar" type="button" class="boton" id="cmdRegresar" value="Regresar"
														onClick="return cmdRegresar_onclick()">
&nbsp;&nbsp;
                    <input name="cmdImprimir" type="button" class="boton" id="cmdImprimir" value="Imprimir la lista"
														onClick="return cmdImprimir_onclick()">
&nbsp;&nbsp; <br>
                    <br>
                  </td>
                </tr>
              </table>
            </td>
            <td width="187" rowspan="2" valign="top" class="tdcolumnader">&nbsp;              
            </td>
          </tr>
          <tr>
            <td colspan="2" class="tdbottom">Sistema Administrador de Puntos
              de Venta - 2003 Farmacias Benavides</td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
</form>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</html>

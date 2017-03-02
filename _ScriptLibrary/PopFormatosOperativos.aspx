<%@ Page CodeBehind="PopFormatosOperativos.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.PopFormatosOperativos" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/FuncionesString.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script LANGUAGE="JavaScript">
<!--
// Function Abre
function Pop(url, width, height) {
  var Win = window.open(url,"Pop",'width=' + width + ',height=' + height + ',left=20,top=20,resizable=yes,scrollbars=auto,menubar=no,status=no' );
}
var strCadenaFormato = strRCookie("strCadenaImagen");

function MuestraReporte() {
    var strCia = "00"  + Trim("<%=intCompaniaId%>");
    var strSuc = "000"  + Trim("<%=intSucursalId%>");
	var strSucursal = strCia.substring(strCia.length -2, strCia.length) + strSuc.substring(strSuc.length -3, strSuc.length);
	var strarchivo = strUrlADSDoc() + "PDF/FormatosOperativos/" +  strSucursal + ".pdf"

}

function strCorteCaja()
{
document.write("<a href=\"" + strUrlADSDoc() + "PDF/FormatosOperativos/" + strCadenaFormato + "/cortedecaja.pdf\" target=\"_blank\" class=\"txsubtituloliga\">Corte de caja</a>");
}
function strDevoluciones()
{
document.write("<a href=\"" + strUrlADSDoc() + "PDF/FormatosOperativos/" + strCadenaFormato + "/devolucionclientes.pdf\" target=\"_blank\" class=\"txsubtituloliga\">Devolución de Clientes</a>");                
}
function strVale()
{
document.write("<a href=\"" + strUrlADSDoc() + "PDF/FormatosOperativos/" + strCadenaFormato + "/valeprovisionalcaja.pdf\" target=\"_blank\" class=\"txsubtituloliga\">Vale Provisional de caja</a>");
}
function strRecPar()
{
document.write("<a href=\"" + strUrlADSDoc() + "PDF/FormatosOperativos/" + strCadenaFormato + "/RecoleccionesParciales.pdf\" target=\"_blank\" class=\"txsubtituloliga\">Control de Recolecciones Parciales</a>");
}
function strFondo()
{
document.write("<a href=\"" + strUrlADSDoc() + "PDF/FormatosOperativos/" + strCadenaFormato + "/ReposiciondeGastos.pdf\" target=\"_blank\" class=\"txsubtituloliga\">Reposicion de Fondo Fijo</a>");
}
function strEntrega()
{
document.write("<a href=\"" + strUrlADSDoc() + "PDF/FormatosOperativos/" + strCadenaFormato + "/EntregaFinal.pdf\" target=\"_blank\" class=\"txsubtituloliga\">Entrega Final </a>");
}
function strMerma()
{
document.write("<a href=\"" + strUrlADSDoc() + "PDF/FormatosOperativos/" + strCadenaFormato + "/Merma.pdf\" target=\"_blank\" class=\"txsubtituloliga\">Formato Merma Controlada</a>");
}
function strNegados()
{
document.write("<a href=\"" + strUrlADSDoc() + "PDF/FormatosOperativos/" + strCadenaFormato + "/Negados.pdf\" target=\"_blank\" class=\"txsubtituloliga\">Control de Negados a Clientes</a>");
}
function strArqueoCajero()
{
document.write("<a href=\"" + strUrlADSDoc() + "PDF/FormatosOperativos/" + strCadenaFormato + "/ArqueodeCajero.pdf\" target=\"_blank\" class=\"txsubtituloliga\">Arqueo de Cajero</a>");
}
function strArqueoFondo()
{
document.write("<a href=\"" + strUrlADSDoc() + "PDF/FormatosOperativos/" + strCadenaFormato + "/ArqueoFondoFijo.pdf\" target=\"_blank\" class=\"txsubtituloliga\">Arqueo Fondo Fijo</a>");
}
function strTarjetasT()
{
document.write("<a href=\"" + strUrlADSDoc() + "PDF/FormatosOperativos/" + strCadenaFormato + "/TarjetasTelefonicas.pdf\" target=\"_blank\" class=\"txsubtituloliga\">Tarjetas Telefonicas</a>");
}

//-->
</script>
</HEAD>
<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0">
<table cellspacing="0" cellpadding="0" width="100%" bgcolor="#ffffff" border="0" class="txcontenido">
  <tr> 
    <td class="tdlogopop" colspan="4" height="54"><script language="javascript">crearTablaHeaderPop()</script></td>
  </tr>
  <tr align="right" valign="bottom" bgcolor="#e6e6e6"> 
    <td colspan="4"><a href="javascript:window.close();" class="txdmigaja">x cerrar 
      ventana</a> &nbsp;&nbsp;</td>
  </tr>
  <tr> 
    <td width="1%">&nbsp;</td>
    <td height="40" colspan="2"><span class="txtitulo">Formatos Operativos </span></td>
    <td width="8%" align="left">&nbsp;</td>
  </tr>
  <tr> 
    <td width="1%">&nbsp;</td>
    <td width="13%" height="40" align="right"><img src="../static/images/imgIconPdf.gif" width="32" height="33">&nbsp; 
    </td>
    <td width="78%" height="20"><script language="javascript">strCorteCaja()</script></td>
    <td width="8%" align="left">&nbsp;</td>
  </tr>
  <tr> 
    <td width="1%">&nbsp;</td>
    <td height="40" align="right"><img src="../static/images/imgIconPdf.gif" width="32" height="33">&nbsp; 
    </td>
    <td height="20"><script language="javascript">strDevoluciones()</script></td>
    <td width="8%" align="left">&nbsp;</td>
  </tr>
  <tr> 
    <td width="1%">&nbsp;</td>
    <td height="40" align="right"><img src="../static/images/imgIconPdf.gif" width="32" height="33">&nbsp; 
    </td>
    <td height="20"><script language="javascript">strVale()</script></td>
    <td width="8%" align="left">&nbsp;</td>
  </tr>
  <tr> 
    <td width="1%">&nbsp;</td>
    <td height="40" align="right"><img src="../static/images/imgIconPdf.gif" width="32" height="33">&nbsp; 
    </td>
    <td height="20"><script language="javascript">strRecPar()</script></td>
    <td width="8%" align="left">&nbsp;</td>
  </tr>
  <tr> 
    <td width="1%">&nbsp;</td>
    <td height="40" align="right"><img src="../static/images/imgIconPdf.gif" width="32" height="33">&nbsp; 
    </td>
    <td height="20"><script language="javascript">strFondo()</script></td>
    <td width="8%" align="left">&nbsp;</td>
  </tr>
  <tr> 
    <td width="1%">&nbsp;</td>
    <td height="40" align="right"><img src="../static/images/imgIconPdf.gif" width="32" height="33">&nbsp; 
    </td>
    <td height="20"><script language="javascript">strEntrega()</script></td>
    <td width="8%" align="left">&nbsp;</td>
  </tr>
  <tr> 
    <td width="1%">&nbsp;</td>
    <td height="40" align="right"><img src="../static/images/imgIconPdf.gif" width="32" height="33">&nbsp; 
    </td>
    <td height="20"><script language="javascript">strMerma()</script></td>
    <td width="8%" align="left">&nbsp;</td>
  </tr>
  <tr> 
    <td width="1%">&nbsp;</td>
    <td height="40" align="right"><img src="../static/images/imgIconPdf.gif" width="32" height="33">&nbsp; 
    </td>
    <td height="20"><script language="javascript">strNegados()</script></td>
    <td width="8%" align="left">&nbsp;</td>
  </tr>
  <tr> 
    <td width="1%">&nbsp;</td>
    <td height="40" align="right"><img src="../static/images/imgIconPdf.gif" width="32" height="33">&nbsp; 
    </td>
    <td height="20"><script language="javascript">strArqueoCajero()</script></td>
    <td width="8%" align="left">&nbsp;</td>
  </tr>
  <tr> 
    <td width="1%">&nbsp;</td>
    <td height="40" align="right"><img src="../static/images/imgIconPdf.gif" width="32" height="33">&nbsp; 
    </td>
    <td height="20"><script language="javascript">strArqueoFondo()</script></td>
    <td width="8%" align="left">&nbsp;</td>
  </tr>
  <tr> 
    <td width="1%">&nbsp;</td>
    <td height="40" align="right"><img src="../static/images/imgIconPdf.gif" width="32" height="33">&nbsp; 
    </td>
    <td height="20"><script language="javascript">strTarjetasT()</script></td>
    <td width="8%" align="left">&nbsp;</td>
  </tr>
  <tr> 
    <td width="1%" height="10">&nbsp;</td>
    <td height="10" align="right">&nbsp; </td>
    <td height="10">&nbsp;</td>
    <td width="8%" align="left">&nbsp;</td>
  </tr>
  <tr valign="bottom"> 
    <td height="17" colspan="4" class="tdbottom">&nbsp;</td>
  </tr>
</table>
</body>
</HTML>

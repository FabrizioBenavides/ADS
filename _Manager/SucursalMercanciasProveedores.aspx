<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" enableViewState="False" Explicit="True" Trace="False" Strict="True" CodeBehind="SucursalMercanciasProveedores.aspx.vb"      Inherits="com.isocraft.backbone.ccentral.SucursalMercanciasProveedores" codePage="28592" %>
<HTML>
<HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name="description" content="Javascript Menu">
<meta name="keywords" content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function goToURL(where) 
	{
	top.location = where; 
	}
	
// done hiding -->
		</script>
</HEAD>
<body>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script>
    </td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est� en : <a href="SucursalHome.aspx">Sucursal</a> :<a href="SucursalMercancias.aspx">Mercancias</a>:Proveedores</td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Mercanc�as Proveedores</h1>
      <p>En esta parte se puede realizar consultas y administrar articulos y
        sucursales asignados a proveedores para la captura de mercanc�as.</p>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="358"><span class="txbluebold12"><a href="SucursalProveedoresConsultar.aspx" class="txbluebold12">Administrar
                Proveedores</a></span></td>
          <td width="43">&nbsp;</td>
          <td width="358"><span class="txbluebold12"><a href="SucursalProveedoresConsultarSucursales.aspx" class="txbluebold12">Administrar
                Relaci�n Sucursal</a></span></td>
        </tr>
        <tr>
          <td width="358"><p>Consultar y cargar los articulos autorizados por
              proveedor.</p>
          </td>
          <td width="43">&nbsp;</td>
          <td><p>Cargar los proveedores a la sucursal o consultarlos.</p>
          </td>
        </tr>
        <tr>
          <td width="358"><span class="txbluebold12"><a href="SucursalProveedoresAltaNuevaSucursal.aspx" class="txbluebold12">Alta
                proveedores nueva sucursal</a></span></td>
          <td width="43">&nbsp;</td>
          <td width="358"><span class="txbluebold12">&nbsp;</span></td>
        </tr>
        <tr>
          <td width="358"><p>Agregar proveedores a una sucursal nueva desde otra
              sucursal.</p>
          </td>
          <td width="43">&nbsp;</td>
          <td>&nbsp; </td>
        </tr>
      </table>
    </td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaFooterCentral()</script>
    </td>
  </tr>
</table>
<script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
		</script>
</body>
</HTML>

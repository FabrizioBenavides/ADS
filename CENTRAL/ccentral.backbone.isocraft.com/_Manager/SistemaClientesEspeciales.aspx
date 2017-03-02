<%@ Page CodeBehind="SistemaClientesEspeciales.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaClientesEspeciales" %>
<HTML>
<HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<LINK href="css/menu.css" type="text/css" rel="stylesheet">
<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

//-->
				</script>
</HEAD>
<body>
<form name="frmPage" action="about:blank" method="post">
  <table cellSpacing="0" cellPadding="0" width="780" border="0">
    <tr>
      <td>
        <script language="JavaScript">crearTablaHeader()</script>
      </td>
    </tr>
  </table>
  <table cellSpacing="0" cellPadding="0" width="780" border="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td class="tdtab" width="770">Está en : <A href="Sistema.aspx">Sistema</A> :
        Clientes especiales</td>
    </tr>
  </table>
  <table cellSpacing="0" cellPadding="0" width="780" border="0">
    <tr>
      <td class="tdgeneralcontent">
        <h1>Clientes especiales </h1>
        <p>En esta parte usted podrá administrar información relacionada con
          clientes especiales; en concreto podrá dar de alta<br>
          formas de captura, editarlas y asignar artículos a clientes especiales
          para ser adquiridos en las sucursales.</p>
        <table cellSpacing="0" cellPadding="0" width="98%" border="0">
          <tr>
            <td><span class="txbluebold12"><A class="txbluebold12" href="VentasAdministrarArticulosExceptosDeDescuento.aspx">Asignar
                  artículos exceptos de descuento</A></span></td>
            <td>&nbsp;</td>
            <td><A class="txbluebold12" href="SistemaAsignarArticulosPrecioFijo.aspx">Asignar
                artículos con precio fijo</A></td>
          </tr>
          <tr>
            <td>
              <p>Aquí podrá dar de alta en el sistema los artículos exceptos
                de descuento y asignárselos a un grupo de clientes especiales.</p>
            </td>
            <td>&nbsp;</td>
            <td>
              <p>Aquí podrá dar de alta en el sistema artículos con precios fijos
                y asignárselos a un cliente especial.</p>
            </td>
          </tr>
          <tr>
            <td><span class="txbluebold12"><A class="txbluebold12" href="VentasAdministrarArticulosNoAutorizados.aspx">Asignar
                  artículos no autorizados para venta a crédito</A></span></td>
            <td>&nbsp;</td>
            <td><span class="txbluebold12"><A class="txbluebold12" href="VentasAdministrarDescuentosPorCliente.aspx">Asignar
                  descuentos por cliente</A></span></td>
          </tr>
          <tr>
            <td>
              <p>Aquí podrá dar de alta en el sistema artículos no autorizados
                para ventas a crédito y asignárselos a un cliente especial.</p>
            </td>
            <td>&nbsp;</td>
            <td>
              <p>Aquí podrá dar de alta en el sistema artículos con descuentos
                y asignárselos a un cliente especial.</p>
            </td>
          </tr>
          <tr>
            <td><span class="txbluebold12"><A class="txbluebold12" href="VentasAdministrarDescuentosPorDepartamento.aspx">Asignar
                  descuentos por divisi&oacute;n categor&iacute;a</A></span></td>
            <td>&nbsp;</td>
            <td><A class="txbluebold12" href="SistemaRecetas.aspx">Revisar Recetas</A></td>
          </tr>
          <tr>
            <td>
              <p>Aquí podrá dar de alta en el sistema descuentos por división
                categoría y asignárselos a un cliente especial.</p>
            </td>
            <td>&nbsp;</td>
            <td>
              <p>Revisar las recetas&nbsp;y autorizaciones de&nbsp;las ventas
                a clientes de credito.</p>
            </td>
          </tr>
          <tr>
            <td width="49%"><A class="txbluebold12" href="SistemaAdministrarClientesNuevos.aspx">Administrar
                clientes</A></td>
            <td width="2%">&nbsp;</td>
            <td width="49%"><A class="txbluebold12" href="SistemaAdministrarTiposDeRecetas.aspx">Administrar
                tipos de recetas</A></td>
          </tr>
          <tr>
            <td vAlign="top" width="49%">
              <p>Aquí podrá consultar, revisar y modificar los datos de un cliente
                especial, incluyendo las sucursales a las que aplicará su<br>
                convenio.</p>
            </td>
            <td width="2%">&nbsp;</td>
            <td vAlign="top" width="49%">
              <p>Alta y edición de tipos de recetas que serán asignadas a diferentes
                clientes especiales.</p>
            </td>
          </tr>
          <tr>
            <td><A class="txbluebold12" href="SistemaAdministrarAtributos.aspx">Administrar
                atributos</A></td>
            <td>&nbsp;</td>
            <td><A class="txbluebold12" href="SistemaAdministrarTiposAtributos.aspx">Administrar
                Tipos de atributos</A></td>
          </tr>
          <tr>
            <td><p>Aquí podrá modificar los atributos que son incluidos en los
                tipos de recetas asignados a clientes especiales.</p>
            </td>
            <td>&nbsp;</td>
            <td><p>Aquí podrá dar de alta o modificar los tipos de atributos
                a los que pertenece un atributo.</p>
            </td>
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
</form>
</body>
</HTML>

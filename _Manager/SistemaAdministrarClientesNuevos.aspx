<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SistemaAdministrarClientesNuevos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SistemaAdministrarClientesNuevos" codePage="1252" enableViewState="False" EnableSessionState="False" %>
<HTML>
<HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
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

function window_onload() {
  document.forms[0].action = "<%= strFormAction %>";
  <%= strJavascriptWindowOnLoadCommands %>
}


function popEditarCliente(intClienteEspecialId,strClienteEspecialNombreId,strClienteEspecialNombre) {
   url = 'popAdministrarClientesNuevos.aspx?intClienteEspecialId=' + intClienteEspecialId + '&strClienteEspecialNombreId=' + strClienteEspecialNombreId + '&strClienteEspecialNombre=' + strClienteEspecialNombre
   var Win = window.open(url,'Pop','width=520,height=320,left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
      
}

function cmdContinuar_onclick() {
   window.location.href = "SistemaAdministrarClientes.aspx";
}

//-->
		</script>
</HEAD>
<body language="javascript" onLoad="return window_onload()">
<form method="post" action="about:blank" name="frmPage">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script>
      </td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : <a href="Sistema.aspx">Sistema</a> : <a href="SistemaClientesEspeciales.aspx"> Clientes
          especiales</a> : Administrar clientes Nuevos</td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0" >
    <tr>
      <td  class="tdgeneralcontent">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td>
              <h1>Clientes Nuevos</h1>
              <p>Aquí debe definir el grupo al cual pertenece el cliente.</p>
            </td>
          </tr>
          <tr>
            <td  align="right"><input name="cmdContinuar" type="button" class="button" id="cmdContinuar" value="Continuar" language=javascript onclick="return cmdContinuar_onclick()">
            </td>
          </tr>
          <tr>
            <td > <%= strGetRecordBrowserHTML() %> </td>
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

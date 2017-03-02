<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalSenalizacionEdicionPromocionesTextoPromocion.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalSenalizacionEdicionPromocionesTextoPromocion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
<HEAD>
<title>Benavides: Edición de Promoción</title>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
<LINK rel="stylesheet" type="text/css" href="css/menu.css">
<LINK rel="stylesheet" type="text/css" href="css/estilo.css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script id="clientEventHandlersJS" language="javascript">

<!--
    strUsuarioNombre = "<%= strUsuarioNombre %>";
    strFechaHora = "<%= strHTMLFechaHora %>";

    function window_onload() {
        document.forms[0].action = "<%= strFormAction %>";

    //Codigo de promocion
    var intPromocionCodigo = "<%= intPromocionCodigo()%>";
    document.getElementById('hdCodigo').value = intPromocionCodigo;

    //Descripcion de la promocion
    var strPromocion = "<%= strPromocion()%>";
    document.getElementById('txtDescripcion').value = strPromocion;
}

function cmdCancelar_onclick() {
    window.close();
}

function frmEditarPromocion_onsubmit() {
    var valida = true;

    if (document.getElementById('txtDescripcion').value == "") {
        alert('Capture la descripción');
        return (false);
    }

    return (valida)
}

//-->
		</script>
</HEAD>
<body language="javascript" onload="return window_onload()">
<form id="frmEditarPromocion" onsubmit="return frmEditarPromocion_onsubmit()" method="post"
			name="frmEditarPromocion" action="about:blank" runat="server">
  <table border="0" cellSpacing="0" cellPadding="0" width="780">
    <tr> 
      <td width="10">&nbsp;</td>
      <td class="tdtab" width="770">Está en : <A href="../_Manager/SucursalHome.aspx">Sucursal</A> 
        : Promociones Texto </td>
    </tr>
  </table>
  <table border="0" cellSpacing="0" cellPadding="0" width="780">
    <tr> 
      <td class="tdgeneralcontent"> <h2>Editar detalle de Promoción</h2>
        <br> <table border="0" cellSpacing="0" cellPadding="0" width="60%">
            <TR> 
            <td class="tdtexttablebold" width="12%">Formato:</td>
            <td class="tdconttablas">
                <%= strFormato()%>
                <input id="idFormato" type="hidden" name="idFormato" value="<%= idFormato() %>">
                <br> 
            </td>
          </TR>
            <tr> 
            <td class="tdtexttablebold" width="12%">Codigo:</td>
            <td class="tdconttablas"> <%= intPromocionCodigo()%> <input id="hdCodigo" type="hidden" name="hdCodigo"> 
              <br> </td>
          </tr>
          <tr> 
            <td class="tdtexttablebold" width="12%">Descripción:</td>
            <td class="tdconttablas"> <input type="text" id="txtDescripcion" class="campotabla" name="txtDescripcion" size="100" maxlength="250"> 
            </td>
          </tr>
          
          <tr> 
            <td class="tdtexttablebold" width="12%"></td>
            <td class="tdconttablas"> <input type="hidden" id="txtNombreArchivo" name="txtNombreArchivo" value="<%= strImagen()%>" /> 
              <a href="#" onclick="window.open('<%= strRutaImagen()%>', 'promocion', 'toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=1,width=400,height=400');"><%= strImagen()%></a> 
            </td>
          </tr>
          <tr> 
            <td class="tdtexttablebold" width="12%">Archivo Imagen</td>
            <td class="tdpadleft5"><input id="txtArchivo" class="field" maxLength="55" size="55" type="file" name="txtArchivo"
										runat="server"> </td>
          </tr>
          <tr> </tr>
        </table>
        <br> <table border="0" cellSpacing="0" cellPadding="0" width="60%">
          <tr> 
            <td class="tdpadleft5" height="20" colSpan="2" align="right"> <input id="cmdGuardar" class="button" value="Guardar" type="submit"name="cmdGuardar"> 
              <input id="cmdRegresar" class="button" onclick="return cmdCancelar_onclick()" value="Regresar" type="button" name="cmdRegresar"> 
            </td>
          </tr>
        </table>
        <br> </td>
    </tr>
  </table>
  <table border="0" cellSpacing="0" cellPadding="0" width="780">
    <tr> 
      <td> <script language="JavaScript">crearTablaFooterCentral()</script> </td>
    </tr>
  </table>
</form>
</body>
</HTML>

<%@ Page CodeBehind="SistemaMedicamentosIlegalesEditar.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaMedicamentosIlegalesEditar" CodePage="1252" EnableSessionState="False" EnableViewState="False" %>

<html>
<head>
    <title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link href="css/menu.css" type="text/css" rel="stylesheet">
    <link href="css/estilo.css" type="text/css" rel="stylesheet">
    <script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
    <script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
    <script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
    <script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
    <script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
    <script language="javascript" id="clientEventHandlersJS">
<!--

    strUsuarioNombre = "<%= strUsuarioNombre %>";
        strFechaHora = "<%= strHTMLFechaHora %>";

        function window_onload() {
            document.forms[0].action = "<%= strFormAction %>";
            document.forms[0].elements["intArticuloId"].value = "<%= intArticuloId%>";
            document.forms[0].elements["txtId"].value = "<%= intArticuloId%>";
            document.forms[0].elements["txtDescripcion"].value = "<%= strArticuloDescripcion%>";
            document.forms[0].elements["txtLote"].value = "<%= strArticuloLote%>";
            var blnArtHabilitado = "<%= blnArticuloVigente%>";
            if (blnArtHabilitado == "True") {
                document.forms[0].elements["chkArticuloHabilitado"][0].checked = blnArtHabilitado;
            } else {
                document.forms[0].elements["chkArticuloHabilitado"][1].checked = blnArtHabilitado;
            }

  <%= strJavascriptWindowOnLoadCommands %>
}

        function ConsultarArticulo() {
            if (blnValidarCampo(document.forms[0].elements["txtArticuloDescripcion"], true, "Producto padre", cintTipoCampoAlfanumerico, 255, 1, "") == true) {
                window.open("../_ScriptLibrary/PopArticulo.aspx?blnSucursal=false&strArticuloIdNombre=" + document.forms[0].elements["txtArticuloDescripcion"].value + "&strArticulo=intArticuloId&strArticuloNombreId=txtArticuloEncontrado&strEvalJs=opener.AutoSubmit()", "Pop", "width=500,height=540,left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no");
            }
        }

        function cmdRegresar_onclick() {
            window.location.href = "<%= "SistemaMedicamentosIlegalesAdministrar.aspx"%>";

            return (true);
        }

        function cmdSalvar_onclick() {
            
            var blnHabilitado = document.forms[0].elements["chkArticuloHabilitado"][0].checked;
            if (blnHabilitado) {
                blnArticuloHabilitado = "True";
            } else {
                blnArticuloHabilitado = "False";
            }
            document.forms[0].action += "?strCmd=Salvar&strOrigen=" + "<%= strOrigen %>" + "&blnArtHabilitado=" + blnArticuloHabilitado;
            document.forms[0].submit();
            return (true);
        }

function strEncabezadoPagina() {
    document.write("Editar Medicamento Ilegal");
}
        //-->
    </script>
</head>
<body language="javascript" onload="return window_onload()">
    <form name="frmMain" action="about:blank" method="post">
        <input type="hidden" value="0" name="intArticuloId">
        <input type="hidden" value="True" name="blnArticuloHabilitado">
        <table cellspacing="0" cellpadding="0" width="780" border="0">
            <tr>
                <td>
                    <script language="JavaScript">crearTablaHeader()</script>
                </td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="0" width="780" border="0">
            <tr>
                <td width="10">&nbsp;</td>
                <td width="770" class="tdtab">Est&aacute; en : <a href="Sistema.aspx">Sistema</a> : <a href="../_Manager/SistemaControlVentas.aspx">Control de Ventas</a> : <a href="../_Manager/SistemaMedicamentosIlegalesAdministrar.aspx">Administrar Empleados Certificados</a> : Editar Medicamento Ilegal</td>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent">
                    <h1>Editar Estatus de Medicamento Ilegal </h1>
                    <p>En esta parte usted puede editar el estatus de medicamentos ilegales de manera individual. </p>
                    <h2>Datos del medicamento</h2>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="tdtexttablebold">Id de Medicamento:</td>
                            <td class="tdcontentableblue"><span class="tdpadleft5">
                                <input name="txtId" type="text" class="fieldborderless" id="txtId" size="35"
                                    maxlength="35" readonly>
                            </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">Descripci&oacute;n:</td>
                            <td class="tdcontentableblue"><span class="tdpadleft5">
                                <input name="txtDescripcion" type="text" class="fieldborderless" id="txtDescripcion" size="255"
                                    maxlength="255" readonly>
                            </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">Lote:</td>
                            <td class="tdcontentableblue"><span class="tdpadleft5">
                                <input name="txtLote" type="text" class="fieldborderless" id="txtLote" size="50"
                                    maxlength="50" readonly>
                            </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">Estatus: </td>
                            <td class="tdtexttablereg">
                                <input name="chkArticuloHabilitado" type="radio" value="1">
                                Habilitado&nbsp;&nbsp;&nbsp;
                                <input name="chkArticuloHabilitado" type="radio" value="0">
                                Deshabilitado</td>
                        </tr>
                        <tr class="txaccion">
                            <td colspan="2">&nbsp;</td>
                        </tr>
                    </table>
                    <input name="cmdSalvar" type="submit" class="button" id="cmdSalvar" value="Salvar" onclick="return cmdSalvar_onclick()">
                    &nbsp;&nbsp;
        <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" onclick="return cmdRegresar_onclick()" value="Regresar">
                    <br>
                </td>
            </tr>
        </table>

        <table cellspacing="0" cellpadding="0" width="780" border="0">
            <tr>
                <td>
                    <script language="JavaScript">crearTablaFooterCentral()</script>
                </td>
            </tr>
        </table>
        <script language="JavaScript">
	<!--
    new menu(MENU_ITEMS, MENU_POS);
    //-->
        </script>
    </form>
</body>
</html>

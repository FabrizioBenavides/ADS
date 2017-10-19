<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SistemaMedicamentosIlegalesAdministrar.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsSistemaMedicamentosIlegalesAgregar" %>

<html>
<head>
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
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
            var intArticuloId = "<%= intArticuloId %>";
            var strArticuloDescripcion = "<%= strArticuloDescripcion%>";
            document.forms[0].action = "<%= strFormAction %>";
            document.forms[0].elements["txtArticuloId"].value = "<%= strtxtArticuloId%>";
            <%= strJavascriptWindowOnLoadCommands %>
        }

        function cmdEjecutar_onclick() {
            if (blnValidarCampo(document.forms[0].elements["txtArticuloId"], false, "BIN", cintTipoCampoEntero, 10, 1, "") == false) {
                return (false);
            } else {
                return (true);
            }
        }

        function cmdAgregar_onclick() {
            if (document.forms[0].elements["txtArchivo"].value.length < 1) {
                alert("Por favor especifique un valor para el campo \"Archivo\".");
                document.forms[0].elements["txtArchivo"].focus();
                return (false);
            }
            document.forms[0].action += "?strCmd=Agregar";
            return (true);
        }

        function cmdReemplazar_onclick() {
            if (document.forms[0].elements["txtArchivo"].value.length < 1) {
                alert("Por favor especifique un valor para el campo \"Archivo\".");
                document.forms[0].elements["txtArchivo"].focus();
                return (false);
            }
            document.forms[0].action += "?strCmd=Reemplazar";
            return (true);
        }

        function cmdEliminar_onclick() {
            if (!confirm('Esta seguro de eliminar la lista de artículos ilegales?')) {
                return;
            }
            else {
                document.forms[0].action += "?strCmd=EliminarTodo";
            }

            return (true);
        }

        function cmdLimpiar_onclick() {
            document.forms[0].elements["txtArticuloId"].value = "";
            document.forms[0].submit();
        }

        //-->
    </script>
</head>
<body language="javascript" onload="return window_onload()">
    <input type="hidden" name="intArticuloId" value="0" />
    <input type="hidden" name="strArticuloDescripcion" value="" />
    <form name="frmMain" action="about:blank" method="post" runat="server">
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <script language="JavaScript">crearTablaHeader()</script>
                </td>
            </tr>
        </table>
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="10">&nbsp;</td>
                <td width="770" class="tdtab">Est&aacute; en : <a href="Sistema.aspx">Sistema</a> : <a href="../_Manager/SistemaControlVentas.aspx">Control de Ventas</a> : Administrar Art&iacute;culos Ilegales</td>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent"  style="height:auto;">
                    <h1>Administrar Art&iacute;culos Ilegales</h1>
                    <p>En esta parte usted administrar&aacute; los Art&iacute;culos Ilegales registrados en el sistema. </p>
                    <h2>Agregar Art&iacute;culos Ilegales</h2>
                    <table width="60%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="12%" class="tdtexttablebold">Archivo:</td>
                            <td class="tdpadleft5">
                                <input name="txtArchivo" id="txtArchivo" type="file" class="field" size="55" maxlength="55" runat="server">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td height="10" colspan="2">
                                <img src="images/pixel.gif" width="1" height="10">
                            </td>
                        </tr>
                        <tr>
                            <td height="10">&nbsp;</td>
                            <td height="10" colspan="2" class="tdpadleft5">
                                <input name="cmdAgregar" type="submit" class="button" id="cmdAgregar" value="Agregar" language="javascript" onclick="return cmdAgregar_onclick()">
                                &nbsp; 
                                <input name="cmdReemplazar" type="submit" class="button" id="cmdReemplazar" value="Reemplazar" language="javascript" onclick="return cmdReemplazar_onclick()">
                                &nbsp; 
                                <input name="cmdEliminar" type="submit" class="button" id="cmdEliminar" value="Eliminar" language=javascript onclick="return cmdEliminar_onclick()">
                            </td>
                        </tr>
                    </table>
                    <br>
                </td>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent">
                    <h2>B&uacute;squeda de Art&iacute;culos Ilegales</h2>
                    <table width="70%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top" class="tdtexttablebold">Id del art&iacute;culo</td>
                            <td valign="top" class="tdpadleft5">
                                <input name="txtArticuloId" type="text" class="field" id="txtArticuloId" size="20" maxlength="20"></td>
                        </tr>
                        <tr>
                            <td height="10" colspan="2">
                                <img src="images/pixel.gif" width="1" height="10"></td>
                        </tr>
                    </table>
                    <input name="cmdEjecutar" type="submit" class="button" id="cmdEjecutar" value="Ejecutar consulta" language="javascript" onclick="return cmdEjecutar_onclick()">
                    <input name="cmdLimpiar" type="button" class="button" id="cmdLimpiar" value="Limpiar" language="javascript" onclick="return cmdLimpiar_onclick()">
                    <br>
                    <br>
                    <%= strObtenerArticulosIlegales()%></td>
            </tr>
        </table>
        <table width="780" border="0" cellspacing="0" cellpadding="0">
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


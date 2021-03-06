<%@ Page CodeBehind="SistemaEmpleadosCertificadosAdministrar.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaEmpleadosCertificadosAgregar" CodePage="1252" EnableSessionState="False" EnableViewState="False" %>

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

        strUsuarioNombre = "<%= strUsuarioNombre %>";
        strFechaHora = "<%= strHTMLFechaHora %>";


        function window_onload() {
            document.forms[0].action = "<%= strFormAction %>";
            document.forms[0].elements["txtEmpleadoId"].value = "<%= strtxtEmpleadoId%>";
             <%= strJavascriptWindowOnLoadCommands %>
        }

        function cmdEjecutar_onclick() {
            if (blnValidarCampo(document.forms[0].elements["txtEmpleadoId"], false, "BIN", cintTipoCampoEntero, 10, 1, "") == false) {
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
            if (!confirm('Esta seguro de eliminar la lista de empleados certificados?')) {
                return;
            }
            else {
                document.forms[0].action += "?strCmd=Eliminar";
            }

            return (true);
        }

        function cmdLimpiar_onclick() {
            document.forms[0].elements["txtEmpleadoId"].value = "";
            document.forms[0].submit();
        }

        function cmdExportar_onclick() {
            var concatenacionExportacion;
            var empleadosCertificados = "<%= strExportarEmpleadosCertificados()%>";
            var guardar;
        
            var ua = window.navigator.userAgent;
            var msie = ua.indexOf("MSIE");

            if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./)) {
                iExportar.document.open("txt/html", "replace");
                iExportar.document.write(empleadosCertificados);
                iExportar.document.close();
                iExportar.focus();
                guardar = iExportar.document.execCommand("SaveAs", true, "Empleados Certificados.xls");
            }
        }

    </script>
</head>
<body language="javascript" onload="return window_onload()">
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
                <td width="770" class="tdtab">Est&aacute; en : <a href="Sistema.aspx">Sistema</a> : <a href="../_Manager/SistemaControlVentas.aspx">Control de Ventas</a> : Administrar Empleados Certificados</td>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent"  style="height:auto;">
                    <h1>Administrar Empleados Certificados</h1>
                    <p>En esta parte usted administrar&aacute; los Empleados Certificados registrados en el sistema. </p>
                    <h2>Agregar Empleados Certificados</h2>
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
                    <%--<h1>Consultar Empleados Certificados</h1>--%>
                    <p>En esta parte usted puede consultar los Empleados Certificados que han sido dados de alta en el sistema. </p>
                    <h2>B&uacute;squeda de Empleados Certificados</h2>
                    <table width="70%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top" class="tdtexttablebold">Id del empleado</td>
                            <td valign="top" class="tdpadleft5">
                                <input name="txtEmpleadoId" type="text" class="field" id="txtEmpleadoId" size="20" maxlength="20"></td>
                        </tr>
                        <tr>
                            <td height="10" colspan="2">
                                <img src="images/pixel.gif" width="1" height="10"></td>
                        </tr>
                    </table>
                    <input name="cmdEjecutar" type="submit" class="button" id="cmdEjecutar" value="Ejecutar consulta" language="javascript" onclick="return cmdEjecutar_onclick()">
                    <input name="cmdLimpiar" type="button" class="button" id="cmdLimpiar" value="Limpiar" language="javascript" onclick="return cmdLimpiar_onclick()">
                    <input name="cmdExportar" type="button" class="button" id="cdmExportar" value="Exportar Todo" language="javascript" onclick="return cmdExportar_onclick()">
                    <br>
                    <br>
                    <%= strObtenerEmpleadosCertificados()%></td>
            </tr>
        </table>
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <script language="JavaScript">crearTablaFooterCentral()</script>
                </td>
            </tr>
        </table>
        <iframe id="iExportar" style="display: none"></iframe>
        <script language="JavaScript">
	<!--
            new menu(MENU_ITEMS, MENU_POS);
    //-->
        </script>
    </form>
</body>
</html>

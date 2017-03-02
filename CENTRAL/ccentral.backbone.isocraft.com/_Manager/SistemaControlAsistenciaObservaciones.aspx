<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SistemaControlAsistenciaObservaciones.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SistemaControlAsistenciaObservaciones" EnableViewState="False" EnableSessionState="False" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html>
<head>
</head>
<title>Benavides : Administrar Observaciones para Asistencia</title>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
<link rel="stylesheet" type="text/css" href="css/menu.css">
<link rel="stylesheet" type="text/css" href="css/estilo.css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<%--<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>--%>

<script id="clientEventHandlersJS" language="javascript">

    strUsuarioNombre = "<%= strUsuarioNombre%>";
    strFechaHora = "<%= strHTMLFechaHora %>";

    function cmdBuscar_onclick() {
        document.forms[0].action = "<%=strFormAction%>";
        document.forms[0].submit();
    }

    function window_onload() {
        cargarControles();

        <%= strJavascriptWindowOnLoadCommands %>
    }

    function cargarControles() {
        document.forms[0].elements["txtBuscaControlAsistenciaObs"].value = "<%=strBuscaControlAsistenciaObservaciones%>";
        var valorCheck = false;
        var strCmd = "";
        strCmd = "<%= strCmd %>";

        if (strCmd === "Actualizar") {
            document.getElementById('lblControlAsistenciaObsId').innerHTML = "<%= intControlAsistenciaObservacionesId%>";
            document.getElementById('txtControlAsistenciaObsNombre').value = "<%= strControlAsistenciaObservacionesNombre%>";

            if ("<%= blnVisible%>".toString().toLowerCase() === "true") {
                valorCheck = true;
            }

            document.forms[0].elements["chkActivo"].checked = valorCheck;
        }
        else if (strCmd === "Agregar") {
            document.getElementById('lblControlAsistenciaObsId').innerHTML = "Nombre";
            document.getElementById('divCamposEditar').style.display = 'inline';
            document.getElementById('divBotonesCancelarGuardar').style.display = 'inline';
            document.getElementById('chkActivo').style.display = 'inline';
        }
        else {
            document.getElementById('divCamposEditar').style.display = 'none';
            document.getElementById('divBotonesCancelarGuardar').style.display = 'none';
            document.getElementById('chkActivo').style.display = 'none';
        }
    }

    function cmdGuardar_onclick() {
        var strCmd = "";
        var intControlAsistenciaObservacionesId;
        var strControlAsistenciaObservacionesNombre;
        var valorCheckbox;
        var intVisible = 0;

        strCmd = "<%= strCmd %>";
        intControlAsistenciaObservacionesId = document.getElementById('lblControlAsistenciaObsId').innerHTML;
        strControlAsistenciaObservacionesNombre = document.getElementById('txtControlAsistenciaObsNombre').value;
        valorCheckbox = document.forms[0].elements["chkActivo"].checked;

        if (strControlAsistenciaObservacionesNombre != "") {

            if (valorCheckbox == true) {
                intVisible = 1;
            }

            if (strCmd == "Actualizar") {
                document.forms[0].action = "SistemaControlAsistenciaObservaciones.aspx?strCmd=Editar" +
                                         "&intControlAsistenciaObservacionesId=" + intControlAsistenciaObservacionesId +
                                         "&strControlAsistenciaObservacionesNombre=" + strControlAsistenciaObservacionesNombre +
                                         "&blnVisible=" + intVisible;

                document.forms(0).submit();
            }
            else if (strCmd == "Agregar") {
                document.forms[0].action = "SistemaControlAsistenciaObservaciones.aspx?strCmd=Nuevo&strControlAsistenciaObservacionesNombre=" +
                                            strControlAsistenciaObservacionesNombre +
                                            "&blnVisible=" + intVisible;

                document.forms(0).submit();
            }
        }
        else {
            window.alert("Favor de capturar el nombre de la observación.");
        }
    }

    function cmdCancelar_onclick() {
        window.location.href = "SistemaControlAsistenciaObservaciones.aspx";
    }

    function cmdNuevo_onclick() {
        document.forms[0].action = "SistemaControlAsistenciaObservaciones.aspx?strCmd=Agregar";
        document.forms[0].submit();
    }

</script>

<body language="javascript" onload="return window_onload()">
</body>

<form method="post" name="frmPage" action="about:blank">
    <table border="0" cellspacing="0" cellpadding="0" width="780">
        <tr>
            <td>
                <script language="JavaScript">crearTablaHeader()</script>
            </td>
        </tr>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="780">
        <tr>
            <td width="10">&nbsp;</td>
            <td class="tdtab" width="770">Está en : <a href="SucursalHome.aspx">Sucursal</a>
                : <a href="SistemaControlAsistenciaObservaciones.aspx">Control de Asistencias</a>
                : Administrar Observaciones para Asistencia</td>
        </tr>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="780">
        <tr>
            <td class="tdgeneralcontent">
                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                    <tr height="20">
                        <td colspan="2">
                            <h1>Administrar Observaciones para Asistencia</h1>
                        </td>
                    </tr>
                    <tr height="30">
                        <td class="tdtexttablebold" width="70%">Observación: 
                            <input class="field" id="txtBuscaControlAsistenciaObs" type="text" autocomplete="off"
                                maxlength="35" size="45" name="txtBuscaControlAsistenciaObs" 
                                value='<%=Request("strBuscaControlAsistenciaObservaciones")%>'>
                        </td>
                        <td align="right" width="30%">
                            <input id="cmdBuscar" language="javascript" class="button"
                                onclick="return cmdBuscar_onclick()"
                                value="Buscar" type="button" name="cmdBuscar">
                        </td>
                        <td>
                            <input id="cmdNuevo" name="cmdNuevo" language="javascript" 
                                class="button" value="Nuevo" type="button" onclick="return cmdNuevo_onclick()" />
                        </td>
                    </tr>
                    <tr height="60">
                        <td class="tdbluebold12" width="70%" align="left" valign="middle">
                            <div id="divCamposEditar">
                                <label id="lblControlAsistenciaObsId" class="tdbluebold12"></label>
                                &nbsp;&nbsp; 
                                <input id="txtControlAsistenciaObsNombre" name="txtControlAsistenciaObsNombre" class="field" maxlength="50" style="width:250px" />
                                &nbsp;&nbsp; 
                                <input id="chkActivo" class="fieldborderless" type="checkbox">
                                <label class="txgreybold">Activo</label>
                            </div>
                        </td>
                    </tr>
                    <tr height="20">
                        <td align="right" width="100%">
                            <div id="divBotonesCancelarGuardar">
                                <input id="cmdCancelar" language="javascript" class="button" onclick="return cmdCancelar_onclick()"
                                    value="Cancelar" type="button" name="cmdCancelar">
                                <input id="cmdGuardar" language="javascript" class="button" onclick="return cmdGuardar_onclick()"
                                    value=" Guardar" type="button" name="cmdGuardar">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"><%= strObtenerControlAsistenciaObs()%> </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="780">
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
</html>

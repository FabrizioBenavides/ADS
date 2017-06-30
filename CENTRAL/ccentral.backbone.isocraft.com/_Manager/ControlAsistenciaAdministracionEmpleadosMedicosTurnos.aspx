<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ControlAsistenciaAdministracionEmpleadosMedicosTurnos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlAsistenciaAdministracionEmpleadosMedicosTurnos" %>

<html>
<head>
    <title>Benavides : Control de Asistencia</title>
    <link href="css/menu.css" rel="stylesheet" type="text/css">
    <link href="css/estilo.css" rel="stylesheet" type="text/css">
    <script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
    
    <script language="JavaScript" type="text/JavaScript">

        strUsuarioNombre = "<%= strUsuarioNombre %>";
        strFechaHora = "<%= strHTMLFechaHora %>";

        function window_onload() {
            <%= strJavascriptWindowOnLoadCommands %>

            ValidarDiaDescanso();
        }

        function ValidarDiaDescanso() {
            var tieneDiaDescanso = '<%=strTieneDiaDescanso%>';
            var intEmpleadoId = '<%=intEmpleadoId%>';

            if(tieneDiaDescanso == "False"){
                window.alert("Debe seleccionar un día de descanso para continuar");

                window.location.href = "ControlAsistenciaAdministracionEmpleadosModificaciones.aspx?strCmd=Editar" +
                                       "&intEmpleadoId=" + intEmpleadoId +
                                       "&blnUsuarioLocal=0";
            }

        }

        function cboEmpleados_onchange() {
            var intEmpId = document.forms[0].elements["cboEmpleados"].value;
            document.location.href = "ControlAsistenciaAdministracionEmpleadosMedicosTurnos.aspx?intEmpleadoId=" + intEmpId;
        }



        new menu(MENU_ITEMS, MENU_POS);
    </script>
</head>
<body onload="return window_onload()">
    <form method="post" action="about:blank" name="frmControlAsistenciaAdministracionEmpleadosMedicosTurnos">
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
                <td width="770" class="tdtab">Est&aacute; en : Sucursal : Control de Asistencia : Administración de Empleados Médicos</td>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent">
                    <h1>Asignación de Horario Médico</h1>
                    <table class="tdenvolventetablas" height="38" cellSpacing="0" cellPadding="0" width="90%">
                        <tr> 
                          <td class="tdtittablas3" valign="top" align="left" colspan="2">Empleado<br>
                            <select id="cboEmpleados" name="cboEmpleados" class='campotabla' onChange='javascript:cboEmpleados_onchange()'>
                                <%= LLenarComboEmpleados()%> 
                            </select>
                          </td>
                        </tr>
                      </table>
                </td>
            </tr>
        </table>
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <script language="JavaScript">crearTablaFooterCentral()</script>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
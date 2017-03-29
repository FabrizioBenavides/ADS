<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" CodeBehind="SistemaClientesAltaNuevaSucursal.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SistemaClientesAltaNuevaSucursal" CodePage="28592" %>

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
    <script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="../static/scripts/FuncionesString.js"></script>

    <script id="clientEventHandlersJS" language="javascript">

        strUsuarioNombre = "<%= strUsuarioNombre %>";
        strFechaHora = "<%= strHTMLFechaHora %>";

        function window_onload() {
            document.forms[0].action = "<%= strFormAction %>";
            <%= strJavascriptWindowOnLoadCommands %>
        }

        // Mandar ventana de consulta
        function Pop(url, width, height) {
            var Win = window.open(url, 'Pop', 'width=' + width + ',height=' + height + ',left=240,top=80,resizable=no,scrollbars=yes,menubar=no,status=no');
            return (false);
        }

        function objLupaSucursal_onclick(intTipoSucursal) {
            var strParametros = '';

            if (intTipoSucursal == 1) { // Tipo Espejo "origen"	  
                strParametros = strParametros + '&campoSucursalNumero=hdnSucursalEspejoId';
                strParametros = strParametros + '&campoSucursalNombre=txtSucursalEspejo';
            }
            if (intTipoSucursal == 2) { // Tipo Nueva "destino"	  
                strParametros = strParametros + '&campoSucursalNumero=hdnSucursalNuevaId';
                strParametros = strParametros + '&campoSucursalNombre=txtSucursalNueva';
            }

            Pop('popSucursalProveedoresElegirSucursal.aspx?' + strParametros + '&strEvalJs=', 520, 240);
        }

        function objLupaClientesAsignados_onclick() {
            var strSucEspejo = document.forms[0].elements['hdnSucursalEspejoId'].value;

            if (strSucEspejo.length < 4) {
                alert('Indicar la sucursal que se usara como espejo');
                return (false);
            }
            strParametros = 'strcmd=VerP&strSucursalId=' + document.forms[0].elements['hdnSucursalEspejoId'].value + "&strSucursalNombre=" + document.forms[0].elements['txtSucursalEspejo'].value;
            Pop('popSucursalProveedoresConsultar.aspx?' + strParametros + '&strEvalJs=', 660, 620);
        }

        function cmdAgregar_onclick() {
            var strSucEspejo = document.forms[0].elements['hdnSucursalEspejoId'].value;
            var strSucNueva = document.forms[0].elements['hdnSucursalNuevaId'].value;

            if (strSucEspejo.length < 4) {
                alert('Indicar la sucursal que se usara como espejo');
                return (false);
            }
            if (strSucNueva.length < 4) {
                alert('Indicar la sucursal nueva');
                return (false);
            }
            if (document.forms[0].elements['hdnSucursalEspejoId'].value == document.forms[0].elements['hdnSucursalNuevaId'].value) {
                alert('La sucursal Nueva no puede ser la misma que la Espejo');
                return (false);
            }

            // Confirmar Actualización
            var msgActualizacion = '\277Cargar los proveedores de la sucursal Espejo: ' + document.forms[0].elements['txtSucursalEspejo'].value
            msgActualizacion = msgActualizacion + '\n a la sucursal nueva : ' + document.forms[0].elements['txtSucursalNueva'].value + '?'

            var intResultado = window.confirm(msgActualizacion);

            if (intResultado) {
                document.forms[0].action = '<%=strFormAction%>?strCmd=AgregarCliente';
                document.forms[0].target = "ifrOculto";
                document.forms[0].submit();
                document.forms[0].target = '';
            }
        }

        function fnUpAgregarClientes(intError, intContadorAlta) {
            document.forms[0].elements['hdnSucursalEspejoId'].value = '';
            document.forms[0].elements['txtSucursalNueva'].value = '';

            document.forms[0].elements['hdnSucursalNuevaId'].value = '';
            document.forms[0].elements['txtSucursalEspejo'].value = '';

            if (intError == -100) {
                alert("No se pudo agregar el cliente a las sucursales indicadas");
            }
            else {
                if (intContadorAlta > 0) {
                    alert("Se agregaron/actualizaron [" + intContadorAlta + "] registros");
                }
                else {
                    alert("No se agrego ningún registro");
                }
            }
        }

        function cmdRegresar_onclick() {
            window.location = "Sistema.aspx";
        }

        new menu(MENU_ITEMS, MENU_POS);
    </script>
</head>
<body>
    <form method="post" id="frmMain" name="frmMain" enctype="multipart/form-data" runat="server">
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
                <td class="tdtab" width="770">Está en : 
                    <a href="Sistema.aspx">Sistema</a> :
                    <a href="">Clientes</a>:Alta Otras Identificaciones a Nueva Sucursal
                </td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="0" width="780" border="0">
            <tr>
                <td class="tdgeneralcontent">
                    <h1>Alta Otras Identificaciones a Nueva Sucursal</h1>
                    <p>
                        A la sucursal indicada como nueva, se le cargarán los clientes
                        de la sucursal indicada como espejo.
                    </p>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td class="tdtexttablebold" width="13%">Sucursal Espejo:</td>
                            <td class="tdtexttablebold" width="02%">
                                <a id="objLupaSucursalEspejo" onclick="objLupaSucursal_onclick(1)">
                                    <img height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0"></a>
                            </td>
                            <td class="tdtexttablebold" width="85%">
                                <span class="txconttablasrojo">&nbsp;
                                    <input class="campotablaresultadoenvolventerojo" id="txtSucursalEspejo"
                                        readonly maxlength="46" size="46" border="0" name="txtSucursalEspejo" value='<%=Request.Form("txtSucursalEspejo")%>'>
                                </span>&nbsp;
                                <a id="objLupaClientesAsignados_onclick" onclick="objLupaClientesAsignados_onclick()">
                                    <img height="17" src="../static/images/imgNRVerA.gif" width="17" align="absMiddle" border="0">
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10">
                                <img height="10" src="images/pixel.gif" width="1">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="13%">Sucursal Nueva:</td>
                            <td class="tdtexttablebold" width="02%">
                                <a id="objLupaSucursalNueva" onclick="objLupaSucursal_onclick(2)">
                                    <img height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0">
                                </a>
                            </td>
                            <td class="tdtexttablebold" width="85%">
                                <span class="txconttablasrojo">&nbsp;
                                <input class="campotablaresultadoenvolventerojo" id="txtSucursalNueva" 
                                    readonly maxlength="46" size="46" border="0" name="txtSucursalNueva" value='<%=Request.Form("txtSucursalNueva")%>'>
                                </span>&nbsp; 
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10">
                                <img height="10" src="images/pixel.gif" width="1">
                            </td>
                        </tr>
                    </table>
                    <input class="boton" id="cmdRegresar" type="button" value="Regresar" name="cmdRegresar"
                        language="javascript" onclick="return cmdRegresar_onclick()">
                    &nbsp;
                    <input class="boton" id="cmdAgregar" type="button" value="Agregar" name="cmdAgregar" language="javascript"
                        onclick="return cmdAgregar_onclick()">
                    <br>
                    <br>
                    <div id="divRB" style="display: none"></div>
                </td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="0" width="780" border="0">
            <tr>
                <td>
                    <script language="JavaScript">crearTablaFooterCentral()</script>
                </td>
            </tr>
            <tr>
                <td>
                    <input type='hidden' name='hdnSucursalEspejoId' value='<%=Request.Form("hdnSucursalEspejoId")%>'>
                    <input type='hidden' name='hdnSucursalNuevaId' value='<%=Request.Form("hdnSucursalNuevaId")%>'>
                </td>
            </tr>
        </table>
    </form>
    <iframe name="ifrOculto" src="" width="0" height="0"></iframe>
</body>
</html>

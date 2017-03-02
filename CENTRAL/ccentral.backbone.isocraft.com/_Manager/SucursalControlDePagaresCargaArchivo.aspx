<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SucursalControlDePagaresCargaArchivo.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalControlDePagaresCargaArchivo" %>

<%@ Import Namespace="Benavides.POSAdmin.Commons" %>


<html>
<head>
    <title>Benavides: Control de Pagares</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link href="css/menu.css" rel="stylesheet" type="text/css">
    <link href="css/estilo.css" rel="stylesheet" type="text/css">
    <script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="../static/scripts/tools.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/calendario.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/cal_format00.js"></script>
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link rel="stylesheet" type="text/css" href="css/menu.css">
    <link rel="stylesheet" type="text/css" href="css/estilo.css">
    <script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
    <script id="clientEventHandlersJS" language="javascript">
<!--

    strUsuarioNombre = "<%= strUsuarioNombre() %>";
        strFechaHora = "<%= strHTMLFechaHora %>";


        function window_onload() {
            document.forms[0].action = "<%= strFormAction %>";

    }

    function strGetCustomDateTime() {
        document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
        return (true);
    }


    function txtArchivo_onfocus() {

        document.getElementById("rbtArchivo").checked = true;
        document.getElementById("txtArchivo").disabled = false;

    }

    function cmdGuardar_onclick() {

        //Variables.
        var valida;

        valida = fnValidaRutaArchivo();
        if (valida) {

                document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdCargar';
                document.forms[0].target = "ifrOculto";
                document.forms[0].target = '_self';
                document.forms[0].submit();
            }

            return (valida);
        }

        function fnValidaRutaArchivo() {

                //Por Código Articulo
                var _archivoRuta = trim(document.getElementById('txtArchivo').value);

                if (_archivoRuta == '') {

                    alert('Indique la ruta del archivo');
                    document.getElementById('txtArchivo').focus();
                    return (false);
                }
                else {

                    var extension = _archivoRuta.substring(_archivoRuta.length - 3)

                    if (extension.toUpperCase() != 'CSV') {

                        alert('El formato del archivo debe de ser .CSV');
                        return (false);
                    }

                }

            return (true);
        }


        
        function trim(stringToTrim) {
            return stringToTrim.replace(/^\s+|\s+$/g, "");
        }

        function cmdCancelar_onclick() {
            window.location.href = "InicioHome.aspx";
        }

        
        //-->
    </script>

</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onload="return window_onload()">
    <form id="frmControlPagaresCarga" name="frmControlPagaresCarga" action="about:blank" method="post" onsubmit="return frmControlPagaresCarga_onsubmit()" runat="server">
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
                <td width="770" class="tdtab">Está en : <a href="../_Manager/InicioHome.aspx">Central</a> : Control de Pagares </td>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent">
                    <div id="divTitulo"></div>
                    <h1>Control de Pagares</h1>
                    <p>
                        Indique la ruta del archivo que contiene la informacion y presione el boton Guardar.&nbsp;El archivo tiene que ser en formato .csv.
                    </p>
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="4">
                                <h2>Alta de Afiliación de Sucursales</h2>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" colspan="4">
                                <%--<input id="rbtArchivo" value="1" type="radio" name="cmdTipoBusqueda" onfocus="return cmdTipoBusqueda_onfocus(this.value)">Por archivo de codigos de articulo--%>
                            </td>

                        </tr>
                        <tr width="100%">
                            <td class="tdtexttablebold" width="12%" align="right">Archivo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td class="tdpadleft5" colspan="3">
                                    <input id="txtArchivo" class="field" maxlength="55" size="55" type="file" name="txtArchivo" runat="server">
                            </td>
                        </tr>
                        </table>
                    <p>
                        <input type="hidden" id="hdnArchivo" name="hdnArchivo">
                        <input type="hidden" id="hdnTotalDePartidas" name="hdnTotalDePartidas">

                        <input class="button" id="cmdGuardar" name="cmdGuardar" value="Guardar" onclick="return cmdGuardar_onclick()" type="button">
                        &nbsp;
                    </p>
                    <div id="tblResultados" class="tdconttablasrojo"></div>
                    <br>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td class="tdpadleft5" align="left" style="width: 65%;">
                                <div id="divBotones"></div>
                            </td>
                            <td class="tdpadleft5" align="right" style="width: 35%;">
                                <div id="divBotnoConfirmar"></div>
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
        <script language="JavaScript">
	<!--
            new menu(MENU_ITEMS, MENU_POS);
    //-->
        </script>
    </form>
    
    <iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</html>
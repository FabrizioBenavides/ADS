<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="popSistemaAgregarClienteOtrasIdentificaciones.aspx.vb" Inherits="com.isocraft.backbone.ccentral.popSistemaAgregarClienteOtrasIdentificaciones" CodePage="28592" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html>
<head>
    <title id="TituloPagina">Benavides: Agregar Cliente Otras Identificaciones</title>
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="css/menu.css" rel="stylesheet" type="text/css" />
    <link href="css/estilo.css" rel="stylesheet" type="text/css" />
    <script type="text/JavaScript" src="js/menu.js"></script>
    <script type="text/JavaScript" src="js/menu_items.js"></script>
    <script type="text/JavaScript" src="js/menu_tpl.js"></script>
    <script type="text/JavaScript" src="js/headerfooter.js"></script>

    <script type="text/javascript">

        strUsuarioNombre = <%= strUsuarioNombre %>;

        function window_onload() {
            <%= strJavascriptWindowOnLoadCommands %>;
            
            establecerEstadoDespuesGuardar();
            establecerTipoVentana();
            establecerValorAControles();
        }

        function establecerEstadoDespuesGuardar() {
            if (<%= ValorGuardar%> === 1){
                window.close();
            }
        }

        function establecerTipoVentana() {
            var strEsActualizarCliente = '<%= strEsActualizarCliente%>';
            var strClienteABFId = "<%= strClienteABFId%>";

            if (strEsActualizarCliente === 'true'){
                document.forms[0].action = "popSistemaAgregarClienteOtrasIdentificaciones.aspx?strCmd2=Buscar" +
                                            "&strClienteABFId=" + strClienteABFId ;
                document.forms[0].submit();
            }
        }

        function establecerValorAControles(){
            if (<%= ValorAsignar%> === 1){
                document.getElementById("TituloPagina").innerHTML ="Benavides: Modificar Cliente Otras Identificaciones";
                document.getElementById("TituloCliente").innerHTML = "<%= strClienteABFId%>" + " - " + "<%= strClienteABFNombre%>";
                document.getElementById("TituloAccion").innerHTML = "Modificar Cliente";
                document.getElementById("txtClaveClienteAbf").readOnly = true;
                document.getElementById("txtClaveClienteAbf").style.background= "lightgrey";
        
                document.getElementById("txtClaveClienteAbf").value = '<%= strClienteABFId%>';
                document.getElementById("txtNombreClienteAbf").value = '<%= strClienteABFNombre%>';
                document.getElementById("txtMensajePos").value = '<%= strMensajePOS%>';
                document.getElementById("txtCredencialUnica").value ='<%= strCredencialUnica%>';
                document.getElementById("txtLlave").value= '<%= strLlaveOnline%>';

                if('<%= blnConsHostExterno%>' === "True"){
                    document.getElementById("cboHost").value= "1";
                }
                else{
                    document.getElementById("cboHost").value= "0";
                }
                document.getElementById("txtCodigoEstatus").value= '<%= strCodigoStatus%>';
                document.getElementById("txtCodigoConfirmacion").value= '<%= strCodigoConfirmaVenta%>';
                document.getElementById("txtReversaConfirmacion").value= '<%= strCodigoReversaVenta%>';
                document.getElementById("cboDvphj").value= '<%= strTieneDVPHJ%>';
                document.getElementById("cboAdjudicaSinEstatus").value= '<%= strAdjudicaSinStatus%>';
                document.getElementById("txtMensajeSinEstatus").value= '<%= strMensajeSinStatus%>';
                document.getElementById("txtBonificacionSinEstatus").value= '<%= fltBonificacionSinStatus%>';
                document.getElementById("txtCreditoSinEstatus").value= '<%= fltCreditoSinStatus%>';
                document.getElementById("cboOrdenCompra").value= '<%= strUsaOrdenDeCompra%>';
                document.getElementById("cboValidaLimiteOc").value= '<%= strValidaLimiteOC%>';
                document.getElementById("txtLimiteOc").value= '<%= intLimiteOC%>';
                document.getElementById("txtClavePadecimiento").value= '<%= strClavePadecimiento%>';
                document.getElementById("txtClaveFamiliar").value= '<%= strClaveFamiliar%>';
                document.getElementById("txtClaveUnica").value= '<%= strClaveUnica%>';
                document.getElementById("txtClaveAutorizacion").value= '<%= strClaveAutorizacion%>';
                document.getElementById("txtDias").value= '<%= strDiasTratamiento%>';
                document.getElementById("txtMensajeCredencial").value= '<%= strMensajeCredencial%>';
                document.getElementById("cboBeneficiariosSinDesp").value= '<%= strSinDespliegueBeneficiarios%>';
                document.getElementById("cboTransaccion").value= '<%= strDuplicaIdTransaccion%>';
            }
        }

        function btnCerrar_onclick() {
            window.close();
        }

        function btnGuardarCliente_onclick() {

            if (!validarCamposVacios()) {
                if (<%= ValorAccion%> === 1){
                    agregarActualizarCliente("Modificar");
                }
                else{
                    agregarActualizarCliente("Agregar");
                }
            }
            else {
                window.alert("Favor de capturar la clave y/o nombre del cliente.");
            }
        }

        function soloNumeros(valor) {
            var esValido = true;
            var valorCaracter = (valor.which) ? valor.which : valor.keyCode;

            if (valorCaracter > 31 && (valorCaracter < 48 || valorCaracter > 57)) {
                esValido = false;
            }

            return esValido;
        }

        function soloNumerosDecimales(txt, valor) {
            var esValido = true;
            var valorCaracter = (valor.which) ? valor.which : valor.keyCode;

            if (valorCaracter == 46) {
                if (txt.value.indexOf('.') === -1) {
                    esValido = true;
                } else {
                    esValido = false;
                }
            } else {
                if (valorCaracter > 31 && (valorCaracter < 48 || valorCaracter > 57))
                    esValido = false;
            }

            return esValido;
        }

        function validarCamposVacios() {
            var hayCamposVacios = false;
            var txtClaveClienteAbf = document.getElementById("txtClaveClienteAbf").value;
            var txtNombreClienteAbf = document.getElementById("txtNombreClienteAbf").value;

            if (txtClaveClienteAbf === "" || txtNombreClienteAbf === "") {
                hayCamposVacios = true;
            }
            return hayCamposVacios;
        }

        function agregarActualizarCliente(accion) {
            var txtClaveClienteAbf = document.getElementById("txtClaveClienteAbf").value;
            var txtNombreClienteAbf = document.getElementById("txtNombreClienteAbf").value;
            var txtMensajePos = document.getElementById("txtMensajePos").value;
            var txtCredencialUnica = document.getElementById("txtCredencialUnica").value;
            var txtLlave = document.getElementById("txtLlave").value;
            var cboHost = document.getElementById("cboHost").value;
            var txtCodigoEstatus = document.getElementById("txtCodigoEstatus").value;
            var txtCodigoConfirmacion = document.getElementById("txtCodigoConfirmacion").value;
            var txtReversaConfirmacion = document.getElementById("txtReversaConfirmacion").value;
            var cboDvphj = document.getElementById("cboDvphj").value;
            var cboAdjudicaSinEstatus = document.getElementById("cboAdjudicaSinEstatus").value;
            var txtMensajeSinEstatus = document.getElementById("txtMensajeSinEstatus").value;
            var txtBonificacionSinEstatus = document.getElementById("txtBonificacionSinEstatus").value;
            var txtCreditoSinEstatus = document.getElementById("txtCreditoSinEstatus").value;
            var cboOrdenCompra = document.getElementById("cboOrdenCompra").value;
            var cboValidaLimiteOc = document.getElementById("cboValidaLimiteOc").value;
            var txtLimiteOc = document.getElementById("txtLimiteOc").value;
            var txtClavePadecimiento = document.getElementById("txtClavePadecimiento").value;
            var txtClaveFamiliar = document.getElementById("txtClaveFamiliar").value;
            var txtClaveUnica = document.getElementById("txtClaveUnica").value;
            var txtClaveAutorizacion = document.getElementById("txtClaveAutorizacion").value;
            var txtDias = document.getElementById("txtDias").value;
            var txtMensajeCredencial = document.getElementById("txtMensajeCredencial").value;
            var cboBeneficiariosSinDesp = document.getElementById("cboBeneficiariosSinDesp").value;
            var cboTransaccion = document.getElementById("cboTransaccion").value;

            document.forms[0].action = "popSistemaAgregarClienteOtrasIdentificaciones.aspx?strCmd2=" + accion  +
                                       "&strClienteABFId=" + txtClaveClienteAbf +
                                       "&strClienteABFNombre=" + txtNombreClienteAbf +
                                       "&strMensajePOS=" + txtMensajePos +
                                       "&strCredencialUnica=" + txtCredencialUnica +
                                       "&strLlaveOnline=" + txtLlave +
                                       "&blnConsHostExterno	=" + cboHost +
                                       "&strCodigoStatus=" + txtCodigoEstatus +
                                       "&strCodigoConfirmaVenta=" + txtCodigoConfirmacion +
                                       "&strCodigoReversaVenta=" + txtReversaConfirmacion +
                                       "&strTieneDVPHJ=" + cboDvphj +
                                       "&strAdjudicaSinStatus=" + cboAdjudicaSinEstatus +
                                       "&strMensajeSinStatus=" + txtMensajeSinEstatus +
                                       "&fltBonificacionSinStatus=" + txtBonificacionSinEstatus +
                                       "&fltCreditoSinStatus=" + txtCreditoSinEstatus +
                                       "&strUsaOrdenDeCompra=" + cboOrdenCompra +
                                       "&strValidaLimiteOC=" + cboValidaLimiteOc +
                                       "&intLimiteOC=" + txtLimiteOc +
                                       "&strClavePadecimiento=" + txtClavePadecimiento +
                                       "&strClaveFamiliar=" + txtClaveFamiliar +
                                       "&strClaveUnica=" + txtClaveUnica +
                                       "&strClaveAutorizacion=" + txtClaveAutorizacion +
                                       "&strDiasTratamiento=" + txtDias +
                                       "&strMensajeCredencial=" + txtMensajeCredencial +
                                       "&strSinDespliegueBeneficiarios=" + cboBeneficiariosSinDesp +
                                       "&strDuplicaIdTransaccion=" + cboTransaccion;
            document.forms[0].submit();
        }

    </script>

</head>
<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0" onload="return window_onload()">
    <form id="frmAgregarCliente" action="about:blank" method="post">
        <table height="158" cellspacing="0" cellpadding="0" width="100%" bgcolor="#ffffff" border="0">
            <tr>
                <td class="tdlogopop" colspan="2" height="21">
                    <img height="54" src="../static/images/logo_pop.gif" width="177">
                </td>
            </tr>
            <tr>
                <td width="2%">&nbsp;</td>
                <td valign="top" width="99%" height="10">
                    <h1 id="TituloCliente"></h1>
                </td>
            </tr>
            <tr>
                <td width="2%">&nbsp;</td>
                <td valign="top" height="30"></td>
            </tr>
            <tr>
                <td width="2%">&nbsp;</td>
                <td>
                    <div style="margin-left: 650px;">
                        <input id="btnCerrar" name="btnCerrar" type="submit"
                            class="boton" value="Cerrar" onclick="return btnCerrar_onclick()">
                        <input id="btnGuardarCliente" type="button" name="btnGuardarCliente"
                            class="boton" value="Guardar Datos" onclick="btnGuardarCliente_onclick()">
                        <br>
                        <br>
                    </div>
                </td>
            </tr>
        </table>
        <table width="500" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="500" class="tdgeneralcontentpop">
                    <h2 id="TituloAccion">Agregar Cliente</h2>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td class="tdtexttablebold" width="30%">Clave Cliente ABF:</td>
                            <td class="tdpadleft5" width="70%">
                                <input id="txtClaveClienteAbf" class="field" type="text" autocomplete="off" maxlength="15" size="30">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Nombre Cliente ABF:</td>
                            <td class="tdpadleft5" width="70%">
                                <input id="txtNombreClienteAbf" class="field" type="text" autocomplete="off" maxlength="255" size="73">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Mensaje POS:</td>
                            <td class="tdpadleft5" width="70%">
                                <textarea id="txtMensajePos" autocomplete="off" style="height: 60px!important;" 
                                    maxlength="2048" rows="5" cols="74" class="field">
                                </textarea>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Credencial Única:</td>
                            <td class="tdpadleft5" width="70%">
                                <input id="txtCredencialUnica" class="field" type="text" autocomplete="off" maxlength="50" size="30">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Llave Online:</td>
                            <td class="tdpadleft5" width="70%">
                                <input id="txtLlave" class="field" type="text" autocomplete="off" maxlength="4" size="30">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Host Externo:</td>
                            <td class="tdpadleft5" width="70%">
                                <select id="cboHost" name="cboHost" class="field" style="width: 50px">
                                    <option value=""></option>
                                    <option value="1">Si</option>
                                    <option value="0">No</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Código Estatus:</td>
                            <td class="tdpadleft5" width="70%">
                                <input id="txtCodigoEstatus" class="field" type="text" autocomplete="off" maxlength="3" size="30">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Código Confirmación Venta:</td>
                            <td class="tdpadleft5" width="70%">
                                <input id="txtCodigoConfirmacion" class="field" type="text" autocomplete="off" maxlength="3" size="30">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Código Reversa Venta:</td>
                            <td class="tdpadleft5" width="70%">
                                <input id="txtReversaConfirmacion" class="field" type="text" autocomplete="off" maxlength="3" size="30">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">DVPHJ:</td>
                            <td class="tdpadleft5" width="70%">
                                <select id="cboDvphj" name="cboDvphj" class="field" style="width: 50px">
                                    <option value=""></option>
                                    <option value="1">Si</option>
                                    <option value="0">No</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Adjudica Sin Estatus:</td>
                            <td class="tdpadleft5" width="70%">
                                <select id="cboAdjudicaSinEstatus" name="cboAdjudicaSinEstatus" class="field" style="width: 50px">
                                    <option value=""></option>
                                    <option value="1">Si</option>
                                    <option value="0">No</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Mensaje Sin Estatus:</td>
                            <td class="tdpadleft5" width="70%">
                                <input id="txtMensajeSinEstatus" class="field" type="text" autocomplete="off" maxlength="255" size="30">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Bonificación Sin Estatus:</td>
                            <td class="tdpadleft5" width="70%">
                                <input id="txtBonificacionSinEstatus" onkeypress="return soloNumerosDecimales(this, event)"
                                    class="field" type="text" autocomplete="off" maxlength="19" size="30">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Credito Sin Estatus:</td>
                            <td class="tdpadleft5" width="70%">
                                <input id="txtCreditoSinEstatus" onkeypress="return soloNumerosDecimales(this, event)"
                                    class="field" type="text" autocomplete="off" maxlength="19" size="30">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Usa Orden de Compra:</td>
                            <td class="tdpadleft5" width="70%">
                                <select id="cboOrdenCompra" name="cboOrdenCompra" class="field" style="width: 50px">
                                    <option value=""></option>
                                    <option value="1">Si</option>
                                    <option value="0">No</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Valida Limite OC:</td>
                            <td class="tdpadleft5" width="70%">
                                <select id="cboValidaLimiteOc" name="cboValidaLimiteOc" class="field" style="width: 50px">
                                    <option value=""></option>
                                    <option value="1">Si</option>
                                    <option value="0">No</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Limite OC:</td>
                            <td class="tdpadleft5" width="70%">
                                <input id="txtLimiteOc" class="field" type="text" onkeypress="return soloNumeros(event)"
                                    autocomplete="off" maxlength="10" size="30">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Clave Padecimiento:</td>
                            <td class="tdpadleft5" width="70%">
                                <input id="txtClavePadecimiento" class="field" type="text" autocomplete="off" maxlength="1" size="30">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Clave Familiar:</td>
                            <td class="tdpadleft5" width="70%">
                                <input id="txtClaveFamiliar" class="field" type="text" autocomplete="off" maxlength="1" size="30">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Clave Única:</td>
                            <td class="tdpadleft5" width="70%">
                                <input id="txtClaveUnica" class="field" type="text" autocomplete="off" maxlength="1" size="30">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Clave Autorización:</td>
                            <td class="tdpadleft5" width="70%">
                                <input id="txtClaveAutorizacion" class="field" type="text" autocomplete="off" maxlength="1" size="30">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Días Tratamiento:</td>
                            <td class="tdpadleft5" width="70%">
                                <input id="txtDias" class="field" type="text" autocomplete="off" maxlength="1" size="30">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Mensaje Credencial:</td>
                            <td class="tdpadleft5" width="70%">
                                <input id="txtMensajeCredencial" class="field" type="text" autocomplete="off" maxlength="50" size="30">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Beneficiarios Sin Despliegue:</td>
                            <td class="tdpadleft5" width="70%">
                                <select id="cboBeneficiariosSinDesp" name="cboBeneficiariosSinDesp" class="field" style="width: 50px">
                                    <option value=""></option>
                                    <option value="1">Si</option>
                                    <option value="0">No</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">Transacción:</td>
                            <td class="tdpadleft5" width="70%">
                                <select id="cboTransaccion" name="cboTransaccion" class="field" style="width: 50px">
                                    <option value=""></option>
                                    <option value="1">Si</option>
                                    <option value="0">No</option>
                                </select>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
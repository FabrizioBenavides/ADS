s<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="popSistemaAgregarClienteOtrasIdentificaciones.aspx.vb" Inherits="com.isocraft.backbone.ccentral.popSistemaAgregarClienteOtrasIdentificaciones" CodePage="28592" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html>
<head>
    <title>Benavides: Agregar Cliente Otras Identificaciones</title>
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="css/menu.css" rel="stylesheet" type="text/css" />
    <link href="css/estilo.css" rel="stylesheet" type="text/css" />
    <script type="text/JavaScript" src="js/menu.js"></script>
    <script type="text/JavaScript" src="js/menu_items.js"></script>
    <script type="text/JavaScript" src="js/menu_tpl.js"></script>
    <script type="text/JavaScript" src="js/headerfooter.js"></script>

    <script type="text/javascript">

        strUsuarioNombre = "<%= strUsuarioNombre %>";


        function window_onload() {

        }

        function btnCerrar_onclick() {
            window.close();
        }

        function btnGuardarCliente_onclick() {

            if (!validarCamposVacios()) {
                agregarCliente();
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
            var hayCamposVacios = true;


            return hayCamposVacios;
        }

        function agregarCliente() {

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
                <td valign="top" width="99%" height="10">&nbsp;</td>
            </tr>
            <tr>
                <td width="2%">&nbsp;</td>
                <td valign="top" height="30"></td>
            </tr>
            <tr>
                <td width="2%">&nbsp;</td>
                <td>
                    <div style="margin-left: 650px;">
                        <input id="btnCerrar" name="btnCerrar" type="submit" class="boton" value="Cerrar" onclick="return btnCerrar_onclick()">
                        <input id="btnGuardarCliente" type="button" name="btnGuardarCliente" class="boton" value="Guardar Datos" onclick="btnGuardarCliente_onclick">
                        <br>
                        <br>
                    </div>
                </td>
            </tr>
        </table>
        <table width="500" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="500" class="tdgeneralcontentpop">
                    <h2>Agregar Cliente</h2>
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
                                <textarea id="txtMensajePos" autocomplete="off" maxlength="2048" rows="5" cols="41" ></textarea>
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

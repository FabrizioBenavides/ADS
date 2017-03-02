<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MercanciaCapturarDevolucionesDeInsumos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaCapturarDevolucionesDeInsumos" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>

<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaCapturarDevolucionesDeInsumos.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para 
    ' Copyright     : 2014 All rights reserved.
    ' Company       : Deintec Soluciones
    ' Author        : Carlos Vazquez
    ' Version       : 1.0
    ' Last Modified : Monday, August 18, 2014
    '====================================================================	
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<meta content="Javascript Menu" name="description">
<meta content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control" name="keywords">
<LINK href="../static/css/menu.css" rel="stylesheet">
<LINK href="../static/css/menu2.css" rel="stylesheet">
<LINK href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/FuncionesString.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--
    //Variables Globales
    blnmControlesEncabezadoHabilitados = true;
    blnRevisando = false;

    var strPaginaAyuda
    strPaginaAyuda = "<%=strThisPageName%>";

function strGetCustomDateTime() {
    document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
    return (true);
}

function strHrefMigaja1() {
    document.location.href = 'Mercancia.aspx';
}
function strHrefMigaja2() {
    document.location.href = 'MercanciaSalidas.aspx';
}
function strHrefMigaja3() {
    document.location.href = 'MercanciaSalidasDevoluciones.aspx';
}
function strHrefMigaja4() {
    document.location.href = '';
}
function strTituloMigaja1() {
    document.write("Mercancía");
}
function strTituloMigaja2() {
    document.write("Salidas");
}
function strTituloMigaja3() {
    document.write("Devolución de insumos de materia prima");
}
function strTituloPrincipalDePagina() {
    document.write("Capturar devoluciones de insumos de materia prima");
}
function strDescripcionPrincipalDePagina() {
    document.write("Capture el proveedor al que se están devolviendo productos, y luego capture los artículos en devolución.");
}

function fnHabilitaDeshabilitaControlesEncabezado(blnHabilitar) {
    if (blnHabilitar) {
        document.forms(0).elements('txtFechaDeDevolucion').readOnly = false;
        document.forms(0).elements('txtFechaDeDevolucion').className = "campotabla";
        document.forms(0).elements('cmbMotivo').disabled = false;
        document.forms(0).elements('cmbMotivo').className = "campotabla";
        document.forms(0).elements('txtProveedorNombreId').readOnly = false;
        document.forms(0).elements('txtProveedorNombreId').className = "campotabla";
        document.forms(0).elements('txtNumeroFactura').readOnly = false;
        document.forms(0).elements('txtNumeroFactura').className = "campotabla";
        document.forms(0).elements('txtNoDeDocumento').readOnly = false;
        document.forms(0).elements('txtNoDeDocumento').className = "campotabla";
        blnmControlesEncabezadoHabilitados = true;

        document.all.divBotones.style.display = 'none';
    }
    else {

        document.forms(0).elements('txtFechaDeDevolucion').readOnly = true;
        document.forms(0).elements('txtFechaDeDevolucion').className = "campotabladeshabilitado";
        document.forms(0).elements('cmbMotivo').disabled = true;
        document.forms(0).elements('cmbMotivo').className = "campotabladeshabilitado";
        document.forms(0).elements('txtProveedorNombreId').readOnly = true;
        document.forms(0).elements('txtProveedorNombreId').className = "campotabladeshabilitado";
        document.forms(0).elements('txtNumeroFactura').readOnly = true;
        document.forms(0).elements('txtNumeroFactura').className = "campotabladeshabilitado";
        document.forms(0).elements('txtNoDeDocumento').readOnly = true;
        document.forms(0).elements('txtNoDeDocumento').className = "campotabladeshabilitado";
        blnmControlesEncabezadoHabilitados = false;

        document.all.divBotones.style.display = '';
    }
}

function blnValidarCifraDeControl() {
    valida = true;
    if (valida) { valida = blnValidarCampo(document.forms(0).elements('txtCifraDeControl'), true, "Cifra de control", cintTipoCampoEntero, 10, 1, ""); }

    if (valida) {

        TotalDePartidas = document.forms[0].elements['hdnTotalArticulosDevolucion'].value;
        TotalDePartidas = TotalDePartidas * 1

        if (TotalDePartidas == 0) {

            alert('Agregue al menos un producto a la devolución.');
            document.forms(0).txtIntArticuloId.focus();
            document.forms(0).txtIntArticuloId.select();
            valida = false;
            return (valida);
        }

        //La suma de todas las partidas debe ser igual a la cifra de control
        intTotal = 0;
        for (i = 1; i < (TotalDePartidas + 1) ; i++) {
            intTotal = (intTotal * 1) + (document.forms(0).elements('txtCantidad_' + i).value * 1);
        }

        inttxtCifraDeControl = (document.forms(0).elements('txtCifraDeControl').value) * 1;
        
        if (inttxtCifraDeControl == intTotal) {
            valida = true;
        }
        else {
            alert('La cifra de control no corresponde al total de artículos.');
            document.forms(0).elements('txtCifraDeControl').select();
            valida = false;
            return (valida);
        }
    }
    return (valida);
}

//Habilitar Controles y hacer submit
function DoSubmit() {

    if (blnmControlesEncabezadoHabilitados) {
        document.forms(0).submit();
    }
    else {

        fnHabilitaDeshabilitaControlesEncabezado(true);
        document.forms(0).submit();
        fnHabilitaDeshabilitaControlesEncabezado(false);
    }
}

function window_onload() {
    MM_preloadImages('../static/images/bsalir_on.gif', '../static/images/bayuda_on.gif');

    <%=strGeneraListaMotivosDeDevolucion("cmbMotivo")%>
	
	<%if strCmbMotivo <> "" then%>
    document.forms[0].elements['cmbMotivo'].value = '<%=strCmbMotivo%>';
	<%end if%>

    if (document.forms[0].elements['hdnTotalArticulosDevolucion'].value == 0) {
        fnHabilitaDeshabilitaControlesEncabezado(true);
        document.forms[0].elements['txtFechaDeDevolucion'].focus();
    }
    else {
        fnHabilitaDeshabilitaControlesEncabezado(false);
        document.forms[0].elements['txtIntArticuloId'].focus();
    }

    return (true);
}

function cmdRegresar_onclick() {
    strHrefMigaja3();
}

function cmdImprimir_onclick() {

    intValor = (document.forms(0).elements('txtDevolucionFolio').value) * 1;
    
    if (intValor > 0) {

        if (window.print) {
            document.ifrPageToPrint.document.all.ToPrintTxtMigaja.innerHTML = document.all.ToPrintTxtMigaja.innerText;
            document.ifrPageToPrint.document.all.ToPrintTxtFecha.innerHTML = document.all.ToPrintTxtFecha.innerText;
            document.ifrPageToPrint.document.all.ToPrintTxtSucursal.innerHTML = document.all.ToPrintTxtSucursal.innerText;
            document.ifrPageToPrint.document.all.ToPrintHtmContenido.innerHTML = document.all.ToPrintHtmContenido.innerHTML;

            //Ocultar 
            document.ifrPageToPrint.document.all.divCapturaDeProductos.style.display = 'none';
            document.ifrPageToPrint.document.all.divBotones.style.display = 'none';

            //Mostrar Tabla de firmas
            document.ifrPageToPrint.document.all.divFirmasHTML.style.display = '';

            document.ifrPageToPrint.focus();
            window.print();
        } else {
            alert("Tu navegador no soporta la función: Print.")
        }
    }
}

function cmdOtraDevolucion_onclick() {

    window.location = "MercanciaCapturarDevolucionesDeInsumos.aspx";
    return (true);
}

// Mandar ventana de consulta
function Pop(url, width, height) {
    var Win = window.open(url, 'Pop', 'width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no');
    return (false);
}

function DoObjCalendar1() {
    if (document.forms(0).elements('txtFechaDeDevolucion').readOnly == false) {
        objCalendar1.popup()
    }
}

// Lupa para listar proveedores
function objLupaProveedor_onclick() {

    var valida = true;
    var intCuentaApostrofes = 0;
    var strTipoProveedor = "";
    var strtxtProveedorNombreId = "";

    if (document.forms[0].elements['txtProveedorNombreId'].readOnly) {
        return (true);
    }

    strtxtProveedorNombreId = Trim(document.forms[0].elements['txtProveedorNombreId'].value);

    if (strtxtProveedorNombreId.length < 1) {
        alert("Teclear Número de proveedor o descripción");
        document.forms[0].elements['txtProveedorNombreId'].focus();
        return (false);
    }

    intCuentaApostrofes = strtxtProveedorNombreId.search("'");

    if (intCuentaApostrofes != -1) {

        document.forms[0].elements['txtProveedorNombreId'].value = '';
        alert("No se deben de capturar apostrofes");
        document.forms[0].elements['txtProveedorNombreId'].focus();
        return (false);
    }

    var strtxtProveedorB = Trim((document.forms[0].elements['txtProveedorNombreId'].value).substring(0, 4));

    if (isNaN(strtxtProveedorB) || strtxtProveedorB.length < 1) // Esta capturando Descripcion
    {
        strEvalJs = 'opener.txtProveedorNombreId_onblur();';
        strParametros = ''
        strParametros = strParametros + ' campoProveedorId=hdnProveedorId';
        strParametros = strParametros + '&campoProveedorNombreId=txtProveedorNombreId';
        strParametros = strParametros + '&campoProveedorRazonSocial=txtRazonSocialProveedor';
        strParametros = strParametros + '&strTipoProveedorNombreId=';
        strParametros = strParametros + '&strProveedorId=' + document.forms[0].elements['txtProveedorNombreId'].value;
        strParametros = strParametros + '&intTipoVigencia=1'; // Solo proveedores vigentes

        Pop('PopProveedorDeInsumos.aspx?' + strParametros + '&strEvalJs=' + strEvalJs, 500, 540);
    }
    else {

        document.forms[0].action = "<%=strFormAction%>?strCmd=BuscarProveedor"
        document.forms[0].target = "ifrOculto";
        document.forms[0].submit();
        document.forms[0].target = '';

   }
}

function txtProveedorNombreId_onKeyDown() {

    if (event.keyCode == 13) { txtProveedorNombreId_onblur() }
    if (event.keyCode == 9) { txtProveedorNombreId_onblur() }
}

function txtProveedorNombreId_onblur() {
    
    strProveedorCapturado = Trim(document.forms[0].elements['txtProveedorNombreId'].value);

    if (strProveedorCapturado.length > 0 && strProveedorCapturado != '0') {
        if (document.forms[0].elements['hdnProveedorNombreId'].value != document.forms[0].elements['txtProveedorNombreId'].value) {
            objLupaProveedor_onclick();
        }
    }
    else {
        document.forms[0].elements['txtProveedorNombreId'].value = '';
        document.forms[0].elements['txtProveedorNombreId'].focus();
        return true;
    }
}

function cmdInicializaProveedor() {
    document.forms(0).txtProveedorNombreId.value = '';
    document.forms(0).txtNumeroFactura.value = '';
}

function fnUpBuscarProveedor(intProveedorId, strProveedorNombreId, strProveedorRazonSocial, strProveedorRFC, intError) {

    if (intError == 0) {
        document.forms(0).hdnProveedorId.value = intProveedorId;
        document.forms(0).hdnProveedorNombreId.value = strProveedorNombreId;
        document.forms(0).txtProveedorNombreId.value = strProveedorNombreId;
        document.forms(0).txtRazonSocialProveedor.value = strProveedorRazonSocial;

        document.forms(0).txtNumeroFactura.focus();
        document.forms(0).txtNumeroFactura.select();
    }
    else {
        alert("Proveedor no encontrado.");

        document.forms(0).hdnProveedorId.value = '';

        document.forms(0).hdnProveedorNombreId.value = '';
        document.forms(0).txtProveedorNombreId.value = '';

        document.forms(0).txtProveedorNombreId.focus();
        document.forms(0).txtProveedorNombreId.select();
    }
}

// Lupa para listar articulos
function objLupaArticulo_onClick() {

    // Es necesario tener los datos de la devolución
    // el numero de proveedor 
    valida = blnDatosDevolucion();

    if (valida == false) {

        return (false);
    }

    valida = blnValidarCampo(document.forms(0).elements("txtProveedorNombreId"), true, "No. de proveedor", cintTipoCampoAlfanumerico, 15, 1, "");
    if (valida == false) { return (false); }

    if (document.forms(0).elements('txtIntArticuloId').value != "") {

        if (!isNaN(document.forms(0).elements('txtIntArticuloId').value)) {

            if (document.forms(0).elements('txtIntArticuloId').value != '0') {
                
                document.forms(0).action = "<%=strFormAction%>?strCmd=BuscarArticulo";
			    document.forms(0).target = "ifrOculto";
			    DoSubmit();
			    document.forms(0).target = '';
			    return (true);

            }
            else {

                //el valor es cero  		     
			    document.forms(0).elements('txtIntArticuloId').value = '';
			    document.forms(0).elements('txtStrArticuloDescripcion').value = '';

			    strEvalJs = "if(opener.document.forms[0].txtIntArticuloId.value!='0'){opener.objLupaArticulo_onClick()}";
			    strEvalJs = 'opener.fnBusquedaArticuloPorIframe();';

			    strParametros = '';
			    strParametros = strParametros + 'campoArticuloId=txtIntArticuloId';
			    strParametros = strParametros + '&campoArticuloDescripcion=txtStrArticuloDescripcion';

			    strParametros = strParametros + '&strArticuloIdNombre=' + document.forms[0].txtIntArticuloId.value;
			    strParametros = strParametros + '&intProveedorId=' + document.forms[0].hdnProveedorId.value;
			    strParametros = strParametros + '&strTipoProveedorNombreId=' + strTipoProveedor;
			    strParametros = strParametros + '&intArticulosCompletos=0';

			    Pop('PopArticuloProveedorInsumosMateriaPrima.aspx?' + strParametros + '&strEvalJs=' + strEvalJs, 500, 540);

            }
               return (false);
        }
        else {

            document.forms(0).elements('txtStrArticuloDescripcion').value = '';

            strEvalJs = "if(opener.document.forms[0].txtIntArticuloId.value!='0'){opener.objLupaArticulo_onClick();}";
            strEvalJs = 'opener.fnBusquedaArticuloPorIframe();';

            strParametros = '';
            strParametros = strParametros + 'campoArticuloId=txtIntArticuloId';
            strParametros = strParametros + '&campoArticuloDescripcion=txtStrArticuloDescripcion';

            strParametros = strParametros + '&strArticuloIdNombre=' + document.forms[0].txtIntArticuloId.value;
            strParametros = strParametros + '&intProveedorId=' + document.forms[0].hdnProveedorId.value;
            strParametros = strParametros + '&strTipoProveedorNombreId=' + strTipoProveedor;
            strParametros = strParametros + '&intArticulosCompletos=1';

            Pop('PopArticuloProveedorInsumosMateriaPrima.aspx?' + strParametros + '&strEvalJs=' + strEvalJs, 500, 540);
        }
    }
    else {

        alert("Teclear número de artículo o descripción");
        document.forms(0).elements('txtIntArticuloId').focus();
        return (false);
    }
}

    function txtIntArticuloId_onKeyDown() {

       if (event.keyCode == 13) { txtIntArticuloId_onblur() }
       if (event.keyCode == 9) { txtIntArticuloId_onblur() }
   }
    
   function txtNumeroFactura_onblur() {

       var intValidaFactura = true;

       if (document.forms(0).txtProveedorNombreId.value == '' && document.forms(0).txtNumeroFactura.value == '') {
           intValidaFactura = false;
       }
       else {
           var intMotivoDevolucion = document.forms[0].elements['cmbMotivo'].value * 1;

           if ((intMotivoDevolucion == 3 || intMotivoDevolucion == 4 || intMotivoDevolucion == 5)) {

               if (intValidaFactura && (document.forms(0).hdnProveedorId.value == '' || isNaN(document.forms(0).hdnProveedorId.value))) {

                   intValidaFactura = false;
                   alert("Capture el Número de Proveedor de la Factura");
                   document.forms(0).txtProveedorNombreId.focus();
               }
               if (document.forms(0).hdnProveedorId.value == '') {
                   intValidaFactura = false;
               }
               else {
                   if (intValidaFactura && document.forms(0).txtNumeroFactura.value == '') {
                       intValidaFactura = false;
                       alert("Capture el Número de Factura");
                       document.forms(0).txtNumeroFactura.focus();
                   }
               }
           }
           else {

               document.forms(0).action = "<%=strFormAction%>?strCmd=BuscarFactura";
               document.forms(0).target = "ifrOculto";
               DoSubmit();
               document.forms(0).target = '';
               return (true);
           }
       }
       
       if (intValidaFactura) {

           document.forms(0).action = "<%=strFormAction%>?strCmd=BuscarFactura";
           document.forms(0).target = "ifrOculto";
           DoSubmit();
           document.forms(0).target = '';
           return (true);
   }
}

    function txtIntArticuloId_onblur() {

        if (Trim(document.forms(0).elements('txtIntArticuloId').value) == '') {

            document.forms(0).txtIntArticuloId.value = '';
            document.forms(0).hdnIntArticuloId.value = '';
            document.forms(0).txtStrArticuloDescripcion.value = '';
            return
    }

        if (document.forms(0).elements('txtIntArticuloId').value != document.forms(0).elements('hdnIntArticuloId').value) {

            if (isNaN(document.forms(0).elements('txtIntArticuloId').value)) {

                //escribo letras
                objLupaArticulo_onClick()
        }
            else {

                //escribio un numero
                objLupaArticulo_onClick()
        }
    }
}

function txtCantidad_onblur() {
    document.forms(0).cmdAgregar.focus();
}

function fnUpdFacturaPorIframe(intFacturaId, intError) {

    document.forms(0).hdnFacturaId.value = intFacturaId;

    if (intError == 0) {
        document.forms(0).txtNoDeDocumento.focus();
    }
    else {
        strMensajeError = "Error al Buscar Factura";

        if (intError == -100) {
            strMensajeError = "Factura no encontrada";
        }

        document.forms(0).txtNumeroFactura.value = '';

        alert(strMensajeError);

        document.forms(0).txtProveedorNombreId.focus();
    }
}

function fnBusquedaArticuloPorIframe() {

    document.forms(0).hdnIntArticuloId.value = document.forms(0).txtIntArticuloId.value;
    var hdnIntArticuloId = document.forms(0).hdnIntArticuloId.value * 1;

    if (hdnIntArticuloId == 0) {
        document.forms(0).txtCantidad.value = '';
        alert("Artículo no encontrado.");
        document.forms(0).txtIntArticuloId.focus();
        document.forms(0).txtIntArticuloId.select();

    }
    else {
        document.forms(0).txtCantidad.focus();
        document.forms(0).txtCantidad.select();
    }

}

function fnUpdArticuloPorIframe(strAccion, strListaHTML, intRegistrosLista, intDevolucionId, intArticuloBuscadoId, strArticuloBuscadoDescripcion, intError) {

    document.forms[0].elements['hdnDevolucionId'].value = intDevolucionId;

    // BUSCAR DE ARTICULO
    if (strAccion == 'BUSCAR') {

        document.forms(0).txtIntArticuloId.value = intArticuloBuscadoId;
        document.forms(0).hdnIntArticuloId.value = intArticuloBuscadoId;
        document.forms(0).txtStrArticuloDescripcion.value = strArticuloBuscadoDescripcion;

        if (intError == 0) {
            document.forms(0).txtCantidad.focus();
            document.forms(0).txtCantidad.select();
        }
        else {

            document.forms(0).txtCantidad.value = '';
            alert("Artículo no encontrado.");
            document.forms(0).txtIntArticuloId.focus();
            document.forms(0).txtIntArticuloId.select();
        }
    }

    // AGREGAR - ELIMINAR ARTICULO
    if (strAccion == 'AGREGAR' || strAccion == 'ELIMINAR') {
        var strMensaje = "";
        document.all.divRecordBrowser.innerHTML = strListaHTML;

        if (intRegistrosLista < 1) {
            fnHabilitaDeshabilitaControlesEncabezado(true); //Habiliar cuando no hay articulos en la devolucion
        }
        else {
            fnHabilitaDeshabilitaControlesEncabezado(false); //Deshabilita si ya hay articulos en la devolucion
        }

        if (intError == 0) {
            document.forms[0].elements['hdnTotalArticulosDevolucion'].value = intRegistrosLista;
        }
        else {
            // AGREGAR ARTICULO A LA DEVOLUCION                                    
            if (strAccion == 'AGREGAR') {

                strMensaje = "Error al agregar Articulo";

                if (intError == -90) {
                    strMensaje = "Capturar una factura valida para el proveedor";
                }

                if (intError == -100) {
                    strMensaje = "No se pudo iniciar el registro de la devolución";
                }
                if (intError == -110) {
                    strMensaje = "No se pudo agregar el articulo a la devolución";
                }
                if (intError == -120) {
                    strMensaje = "El articulo no existe para el proveedor";
                }
            }

            // ELIMINAR ARTICULO A LA TRANSFERENCIA                  
            if (strAccion == 'ELIMINAR') {
                strMensaje = "Error al eliminar Articulo";

                if (intError == -100) {
                    strMensaje = "No se pudo eliminar el articulo de la transferencia";
                }
            }
            alert(strMensaje);
        }

        document.forms(0).txtIntArticuloId.value = '';
        document.forms(0).txtStrArticuloDescripcion.value = '';
        document.forms(0).txtCantidad.value = '';
        document.forms(0).txtIntArticuloId.focus();

    }
}

function fnRegistrarDevolucionPorIframe(strListaHTML, intRegistrosLista, intDevolucionId, intDevolucionFolioId, intError) {
    if (intError == 0) {
        document.forms[0].elements['txtDevolucionFolio'].value = intDevolucionFolioId;

        document.forms[0].elements['cmdRegistrar'].disabled = true;
        document.forms[0].elements['cmdRegistrar'].title = 'La devolución ya fue registrada.';

        document.forms[0].elements['txtCifraDeControl'].readOnly = true;
        document.forms[0].elements['txtCifraDeControl'].className = "campotabladeshabilitado";
        document.forms[0].elements['txtCifraDeControl'].title = 'La devolución ya fue registrada.';

        document.forms[0].elements['cmdAgregar'].disabled = true;
        document.forms[0].elements['cmdAgregar'].title = 'La devolución ya fue registrada.';

        document.all.divCapturaDeProductos.style.display = 'none';
        document.forms(0).cmdOtraCaptura.style.display = '';

        alert("Devolución Registrada con el Folio : [" + intDevolucionFolioId + "]");
    }
    else {
        alert("No fue posible registrar la Devolución.");
    }

}

function blnDatosDevolucion() {

    //Validaciones
    var valida = true;

    //fecha de devolucion
    if (valida) {

        valida = blnValidarCampo(document.forms(0).elements("txtFechaDeDevolucion"), true, "Fecha de devolución", cintTipoCampoFecha, 10, 10, "");
    }

    if (valida) {

        strFecha = document.forms[0].elements("txtFechaDeDevolucion").value.substr(3, 2) + "/" + document.forms[0].elements("txtFechaDeDevolucion").value.substr(0, 2) + "/" + document.forms[0].elements("txtFechaDeDevolucion").value.substr(6, 4)

        if (Date.parse(strFecha) > Date.parse("<%=clsCommons.strGetCustomDateTime("MM/dd/yyyy")%>")) {

	        alert("Fecha devolución inválida");
	        document.forms[0].elements("txtFechaDeDevolucion").focus();
	        valida = false;
	    }
    }
    //Motivo
    if (valida) { valida = blnValidarCombo(document.forms(0).elements('cmbMotivo'), '-1', 'Motivo', true) }

    //No de proveedor
    if (valida) { valida = blnValidarCampo(document.forms(0).elements("txtProveedorNombreId"), true, "No. de proveedor", cintTipoCampoAlfanumerico, 15, 1, ""); }

    //Factura
    if (valida) {

        var intMotivoDevolucion = document.forms[0].elements['cmbMotivo'].value * 1;
        var hdnFacturaId = document.forms[0].elements['hdnFacturaId'].value * 1;

        if (hdnFacturaId < 1 && (intMotivoDevolucion == 3 || intMotivoDevolucion == 4 || intMotivoDevolucion == 5)) {

            alert("La Factura debe existir como confirmada");
            document.forms(0).elements("txtNumeroFactura").focus();
            valida = false;
        }
        else {
            valida = blnValidarCampo(document.forms(0).elements("txtNumeroFactura"), true, "Factura", cintTipoCampoAlfanumerico, 20, 1, "");
        }
    }

    //No de documento
    if (valida) { valida = blnValidarCampo(document.forms(0).elements("txtNoDeDocumento"), true, "No. de documento", cintTipoCampoEntero, 5, 1, ""); }

    return valida;

}

function intAgregarArticulo() {

    //Validaciones
    valida = blnDatosDevolucion();

    //Codigo
    if (valida) { valida = blnValidarCampo(document.forms(0).elements("txtIntArticuloId"), true, "Código", cintTipoCampoEntero, 20, 1, ""); }

    if (valida) {
        if (document.forms(0).elements("txtIntArticuloId").value <= 0) {

            document.forms(0).elements("txtIntArticuloId").value = '';
            document.forms(0).elements("txtIntArticuloId").focus();
            valida = false;
        }
    }

    //Cantidad
    if (valida) { valida = blnValidarCampo(document.forms(0).elements("txtCantidad"), true, "Cantidad", cintTipoCampoEntero, 15, 1, ""); }

    if (valida) {
        if (document.forms(0).elements("txtCantidad").value <= 0) {

            alert("Cantidad no válida");
            document.forms(0).elements("txtCantidad").focus();
            valida = false;
        }
    }

    //submit
    if (valida) {

        document.forms[0].action = "<%=strFormAction%>?strCmd=AgregarArticulo";
	    document.forms[0].target = "ifrOculto";
	    DoSubmit();
	    document.forms[0].target = '';
	}

}

    function intEliminarArticulo(intDevolucionId, intArticuloId) {

        intValor = (document.forms(0).elements('txtDevolucionFolio').value) * 1;

        if (intValor > 0) {

            alert('Imposible borrar, la devolución ya fue registrada.');
        }
        else {

            document.forms(0).action = "<%=strFormAction%>?strCmd=EliminarArticulo&intDevolucionIdEliminar=" + intDevolucionId + "&intArticuloIdEliminar=" + intArticuloId;

	        document.forms(0).target = "ifrOculto";
	        DoSubmit();
	        document.forms(0).target = '';
        }
    }

    function txtCifraDeControl_onKeyDown() {

        if (event.keyCode == 13) { document.forms(0).cmdRegistrar.click(); }
    }

function cmdRegistrar_onclick() {

    //Validaciones
    valida = blnDatosDevolucion();

    if (valida) { valida = blnValidarCifraDeControl(); }

    if (valida) {
        document.forms(0).action = "<%=strFormAction%>?strCmd=Registrar";
    }

    if (valida) {
        document.forms(0).target = "ifrOculto";
        DoSubmit();
        document.forms(0).target = '';
    }
}

    function cmdonKeyPressed(intObjeto, tecla) {

    if (tecla == 13 || tecla == 9) {
        if (intObjeto == 1) {
            document.forms(0).cmbMotivo.focus();
        }
        
        if (intObjeto == 3) {
            document.forms(0).txtProveedorNombreId.focus();
        }

        if (intObjeto == 4) {
            document.forms(0).txtNumeroFactura.focus();
        }

        if (intObjeto == 5) {
            document.forms(0).txtNoDeDocumento.focus();
        }

        if (intObjeto == 6) {
            document.forms(0).txtIntArticuloId.focus();
        }
        
        if (intObjeto == 10) {
            document.forms(0).txtCantidad.focus();
        }

        if (intObjeto == 11) {
            document.forms(0).cmdAgregar.focus();
        }

        event.returnValue = false;
    }
}


//-->
</script>
</HEAD>
<body leftMargin="0" topMargin="0" onload="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmMercanciaCapturarDevolucionesInsumos" action="about:blank" method="post">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98" width="100%"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td valign="top" height="34" width="100%"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td width="100%"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgColor="#ffffff"><IMG height="8" src="../static/images/pixel.gif" width="10"></td>
            <td class="tdmigaja" width="583"> <div id="ToPrintTxtMigaja"><span class="txdmigaja">Está 
                en : </span><A class="txdmigaja" href="javascript:strHrefMigaja1();"> 
                <script language="javascript">strTituloMigaja1()</script>
                </A> <span class="txdmigaja">: <A class="txdmigaja" href="javascript:strHrefMigaja2();"> 
                <script language="javascript">strTituloMigaja2()</script>
                </A>: <A class="txdmigaja" href="javascript:strHrefMigaja3();"> 
                <script language="javascript">strTituloMigaja3()</script>
                </A>: 
                <script language="javascript">strTituloPrincipalDePagina()</script>
                </span></div></td>
            <td class="tdfechahora" width="182"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td class="tdtablacont" vAlign="top" width="583"><span class="txtitulo"> 
              <script language="javascript">strTituloPrincipalDePagina()</script>
              </span><span class="txcontenido"> 
              <script language="javascript">strDescripcionPrincipalDePagina()</script>
              <br>
              </span> <script language="JavaScript">crearDatosSucursal()</script> 
              <br> <div id="ToPrintHtmContenido"> 
                <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                  <tr> 
                    <td class="tdtittablas" width="30%">Folio de Devolución:</td>
                    <td class="tdpadleft5" vAlign="middle" width="70%"><input class="campotabladeshabilitado" readOnly type="text" maxLength="4" size="18" name="txtDevolucionFolio"> 
                    </td>
                  </tr>
                </table>
                <br>
                <span class="txsubtitulo"><IMG height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Datos 
                de la Devolución</span> 
                <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                  <tr> 
                    <td class="tdtittablas" width="25%">Fecha de Devolución:</td>
                    <td class="tdpadleft5" width="75%" vAlign="middle"><input class="campotabla" onkeypress="cmdonKeyPressed(1,event.keyCode);" type="text" size="10"
														name="txtFechaDeDevolucion"> 
                      <IMG style="CURSOR: hand" onclick="if(blnValidarCampo(document.forms(0).elements('txtFechaDeDevolucion'),false,'Fecha de devolución',cintTipoCampoFecha,10,10,'')){DoObjCalendar1();}"
														height="13" src="../static/images/icono_calendario.gif" width="20" align="absMiddle"></td>
                  </tr>
                  <tr> 
                    <td height="29" class="tdtittablas" width="25%">Motivo Devolución:</td>
                    <td class="tdpadleft5" vAlign="middle" width="75%"><select class="campotabla" onkeypress="cmdonKeyPressed(2,event.keyCode);" onchange="cmdInicializaProveedor()"
														name="cmbMotivo">
                      </select> </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" width="25%">No. de proveedor:</td>
                    <td class="tdpadleft5" width="75%"> <input name="txtProveedorNombreId" id="txtProveedorNombreId" type="text" class="campotabla" value='<%=Request.Form("txtProveedorNombreId")%>'  autocomplete="off" size="16" maxLength="16" onblur="return txtProveedorNombreId_onblur()" onkeydown="txtProveedorNombreId_onKeyDown()" onkeypress="cmdonKeyPressed(4,event.keyCode);"> 
                      &nbsp; <A id="objLupaProveedor" onclick="return objLupaProveedor_onClick()"><IMG height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0"></A> 
                      <span class="txconttablasrojo"> 
                      <input class="campotablaresultado" id="txtRazonSocialProveedor" readOnly maxLength="40"
															size="40" border="0" name="txtRazonSocialProveedor">
                      </span></td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" width="25%">No. de Factura:</td>
                    <td class="tdpadleft5" width="75%" vAlign="middle"><input class="campotabla" onkeypress="cmdonKeyPressed(5,event.keyCode);" onblur="return txtNumeroFactura_onblur()"
														type="text" size="20" name="txtNumeroFactura"> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" width="25%">No. de Documento:</td>
                    <td class="tdpadleft5" width="75%" vAlign="middle"><input class="campotabla" onkeypress="cmdonKeyPressed(6,event.keyCode);" type="text" maxLength="5"
														size="20" name="txtNoDeDocumento"> 
                    </td>
                  </tr>
                </table>
                <br>
                <span class="txsubtitulo"><IMG height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Detalle 
                de productos devueltos</span> 
                <div id="divRecordBrowser"></div>
                <br>
                <div id="divCapturaDeProductos"> 
                  <table class="tdenvolventetablas" width="100%">
                    <tr> 
                      <td class="tdtittablas3" align="left" width="100">Código:</td>
                      <td class="tdtittablas3" align="left" width="120">Cantidad</td>
                      <td class="tdtittablas3" align="left" width="240">Descripción</td>
                      <td vAlign="middle" width="80" rowSpan="2"><input class="boton" type="button" name="cmdAgregar" onclick="return intAgregarArticulo()"
															value="Agregar"> </td>
                    </tr>
                    <tr> 
                      <td class="txtitintabla" vAlign="middle" width="190" height="21"><input class="campotabla" onkeypress="cmdonKeyPressed(10,event.keyCode);" onblur="txtIntArticuloId_onblur();"
															type="text" maxLength="16" size="18" name="txtIntArticuloId"> 
                        <a id="objLupaArticulo" onclick="return objLupaArticulo_onClick();" border="0"> 
                        <IMG height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0"> 
                        </a> </td>
                      <td class="tdpadleft5" vAlign="middle"><input class="campotabla" onkeypress="cmdonKeyPressed(11,event.keyCode);" onblur="return txtCantidad_onblur()"
															type="text" maxLength="4" size="18" name="txtCantidad"> 
                      </td>
                      <td class="txtitintabla" vAlign="middle" width="300"><input class="campotablaresultadoenvolventeazul" readOnly type="text" size="32" name="txtStrArticuloDescripcion"> 
                      </td>
                    </tr>
                  </table>
                </div>
                <br>
                <div id="divBotones" style="DISPLAY: none"> 
                  <table id="TblBotones" cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <tr> 
                      <td width="317">&nbsp;&nbsp; <input class="boton" onclick="return cmdRegresar_onclick()" type="button" value="Regresar"
															name="cmdRegresar"> 
                        <input class="boton" onclick="return cmdImprimir_onclick()" type="button" value="Imprimir"
															name="cmdImprimir"> 
                        <input class="boton" style="DISPLAY: none" onclick="return cmdOtraDevolucion_onclick()"
															type="button" value="Otra Captura" name="cmdOtraCaptura"> 
                      </td>
                      <td class="tdenvolventetablas" align="center" width="200" bgColor="#f4f6f8"> 
                        <table cellSpacing="0" cellPadding="0" width="230" border="0">
                          <tr> 
                            <td class="tdtittablas3" width="156">Cifra de control</td>
                            <td width="91" rowSpan="2"><input class="boton" onclick="return cmdRegistrar_onclick()" type="button" value="Registrar"
																		name="cmdRegistrar"> 
                            </td>
                          </tr>
                          <tr> 
                            <td vAlign="top" height="30"><input class="campotabla" onkeydown="txtCifraDeControl_onKeyDown()" type="text" maxLength="4"
																		size="16" name="txtCifraDeControl"> 
                            </td>
                          </tr>
                        </table></td>
                    </tr>
                  </table>
                </div>
                <br>
                <div id="divFirmasHTML" style="DISPLAY: none"> 
                  <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <tr> 
                      <td>_________________</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td>_________________</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td>_________________</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td>_________________</td>
                    </tr>
                    <tr> 
                      <td class="tdtittablas" align="center">Nombre y Firma</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Nombre y Firma</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Nombre y Firma</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Nombre y Firma</td>
                    </tr>
                    <tr> 
                      <td class="tdtittablas" align="center">Chofer Repartidor</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Rpte. de Ventas</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Capturó Devolución</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Gte. Sucursal</td>
                    </tr>
                  </table>
                  <br>
                  <table>
                    <tr> 
                      <td class="tdtittablas">* Este documento no será válido 
                        sin el nombre y firma de autorización del representante 
                        del proveedor.* </td>
                    </tr>
                  </table>
                </div>
              </div>
              <!-- cerramos el div ToPrintHtmContenido -->
            </td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"> <script language="javascript">strGeneraTablaAyuda('');
									</script> </td>
          </tr>
          <tr> 
            <td class="tdbottom" colSpan="2"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
    <tr> 
      <td> <input type="hidden" name="hdnDevolucionId"> <input type="hidden" name="hdnFacturaId" value= '<%=Request.Form("hdnFacturaId")%>'> 
        <input type='hidden' name='hdnProveedorId' value= '<%=Request.Form("hdnProveedorId")%>'> 
        <input type='hidden' name='hdnProveedorNombreId' value= '<%=Request.Form("hdnProveedorNombreId")%>'> 
        <input type="hidden" name="hdnIntArticuloId"> <input type="hidden" name="hdnTotalArticulosDevolucion"> 
      </td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
    new menu(MENU_ITEMS, MENU_POS);
    new menu(MENU_ITEMS2, MENU_POS2);
    var objCalendar1 = new calendar1(document.forms[0].elements['txtFechaDeDevolucion']);
    //-->
			</script>
</form>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</HTML>

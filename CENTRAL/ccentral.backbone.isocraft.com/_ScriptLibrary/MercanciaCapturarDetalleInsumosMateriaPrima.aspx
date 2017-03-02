<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MercanciaCapturarDetalleInsumosMateriaPrima.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaCapturarDetalleInsumosMateriaPrima" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>

<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : MercanciaCapturarDetalleInsumosMateriaPrima.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Captura el Detalle de los Insumos de Materia Prima
    ' Copyright     : 2014 All rights reserved.
    ' Company       : Deintec
    ' Author        : Carlos Vazquez
    ' Version       : 1.0
    ' Last Modified : 
    '                 Miercoles, Agosto 13, 2014
    '====================================================================
%>
<link href="../static/css/menu.css" rel="stylesheet">
<link href="../static/css/menu2.css" rel="stylesheet">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--
    function LTrim(s) {
        // Devuelve una cadena sin los espacios del principio
        var i = 0;
        var j = 0;

        // Busca el primer caracter <> de un espacio
        for (i = 0; i <= s.length - 1; i++)
            if (s.substring(i, i + 1) != ' ') {
                j = i;
                break;
            }
        return s.substring(j, s.length);
    }
    function RTrim(s) {
        // Quita los espacios en blanco del final de la cadena
        var j = 0;

        // Busca el último caracter <> de un espacio
        for (var i = s.length - 1; i > -1; i--)
            if (s.substring(i, i + 1) != ' ') {
                j = i;
                break;
            }
        return s.substring(0, j + 1);
    }
    function Trim(s) {
        // Quita los espacios del principio y del final
        return LTrim(RTrim(s));
    }
    function strEliminacommas(objcampo) {
        // Quita las comas 
        while (parseInt(objcampo.search(',')) > 0) {
            objcampo = objcampo.replace(',', '');
        }

        // quita el signo de pesos
        objcampo = objcampo.replace('$', '');
        return (objcampo);
    }

    function fnBuscaPuntoDecimal(strCampo) {
        var intCaracteresTotales;
        var intContador;
        var intCuentaPuntoDecimal;
        var straValidar;

        intCaracteresTotales = strCampo.length;
        intContador = 0;
        intCuentaPuntoDecimal = 0;

        while (intContador <= intCaracteresTotales) {
            straValidar = strCampo.substring(intContador, intContador + 1)
            if (straValidar == ".") {
                intCuentaPuntoDecimal = intCuentaPuntoDecimal + 1;
            }
            intContador = intContador + 1;
        }
        return (intCuentaPuntoDecimal);
    }

    // Mandar ventana de consulta
    function Pop(url, width, height) {
        var Win = window.open(url, 'Pop', 'width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no');
        return (false);
    }
    function strGetCustomDateTime() {
        document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
    return (true);
}
function strRecordBrowserHTML() {
    document.all.divDetalle.innerHTML = "<%=strRecordBrowserHTML%>";
    return (true);
}

function strProveedorNombreId() {
    document.write("<%= Request("txtProveedorNombreId") %>");
    return (true);
}

function strRazonSocialProveedor() {
    document.write("<%= Request("txtRazonSocialProveedor")%>");
    return (true);
}
function strFolioOrdenId() {
    return (true);
}
function strNumeroFactura() {
    document.write("<%= Request("txtNumeroFactura") & Request("txtNumeroFacturaRuta") %>");
    return (true);
}

function dtmFechaFactura() {
    document.write("<%= Request("txtFechaFactura")%>");
    return (true);
}

function strFechaRecepcion() {
    document.write("<%=Request("txtFechaRecepcion")%>");
    return (true);
}

function fltTotalFacturado() {
    document.write("<%=fltTotalFacturado%>");
    return (true);
}

function objLupa2Articulo_onClick() {
    var strArticulo
    var intCuentaApostrofes

    strArticulo = document.forms[0].elements['txtArticuloId'].value;
    intCuentaApostrofes = strArticulo.search("'");

    if (intCuentaApostrofes != -1) {
        alert("No se deben de capturar apostrofes");
        document.forms[0].elements['txtArticuloId'].value = '';
        document.forms[0].elements['txtArticuloId'].focus();
        return (false);
    }

    if (document.forms[0].txtArticuloId.value != "") {
        if (!isNaN(document.forms[0].txtArticuloId.value)) {
            if (document.forms[0].txtArticuloId.value != '0') {
                document.forms[0].action = "<%=strFormAction%>?strCmd=BuscarArticulo&<%=strFormActionParameters%>";
			       document.forms[0].target = "ifrOculto";
			       document.forms[0].submit();
			       document.forms[0].target = '';
			       return (true);
			   }
			   else {
			       //el valor es cero  		     
			       document.forms[0].txtArticuloId.value = '';
			       document.forms[0].txtDescripcionArticulo.value = '';

			       strParametros = '';
			       strParametros = strParametros + 'campoArticuloId=txtArticuloId';
			       strParametros = strParametros + '&campoArticuloDescripcion=txtDescripcionArticulo';
			       strParametros = strParametros + '&campoArticuloCostoReposicion=txtCostoReposicion';
			       strParametros = strParametros + '&strArticuloIdNombre=' + document.forms[0].txtArticuloId.value;
			       strParametros = strParametros + '&intProveedorId=' + document.forms[0].hdnProveedorId.value;
			       strParametros = strParametros + '&strTipoProveedorNombreId=INSUMOSMATERIAPRIMA'
			       strParametros = strParametros + '&intArticulosCompletos=0';

			       Pop('PopArticuloProveedorInsumosMateriaPrima.aspx?' + strParametros, 500, 540);
			   }
               return (false);
           }
           else {
               document.forms(0).txtDescripcionArticulo.value = '';

               strParametros = '';
               strParametros = strParametros + 'campoArticuloId=txtArticuloId';
               strParametros = strParametros + '&campoArticuloDescripcion=txtDescripcionArticulo';
               strParametros = strParametros + '&campoArticuloCostoReposicion=txtCostoReposicion';
               strParametros = strParametros + '&strArticuloIdNombre=' + document.forms[0].txtArticuloId.value;
               strParametros = strParametros + '&intProveedorId=' + document.forms[0].hdnProveedorId.value;
               strParametros = strParametros + '&strTipoProveedorNombreId=INSUMOSMATERIAPRIMA'
               strParametros = strParametros + '&intArticulosCompletos=0';

               Pop('PopArticuloProveedorInsumosMateriaPrima.aspx?' + strParametros, 500, 540);
           }
       }
       else {
           alert("Teclear número de artículo o descripción");
           document.forms[0].txtArticuloId.focus();
           return (false);
       }
   }

    function txtCantidad_onfocus() {

       document.forms[0].txtCantidad.select();

       strValor = LTrim(RTrim(document.forms[0].elements['txtArticuloId'].value));
       strCuenta = strValor.length;

       if (parseInt(strCuenta) > 0) {
           if (Trim(document.forms[0].elements['txtArticuloId'].value) != Trim(document.forms[0].elements['hdnArticuloAnteriorId'].value)) {
               //if (document.forms[0].elements['hdnSoloOrden'].value == 1) {
               //    alert("ERROR \n\rNo se puede agregar articulos a la compra,\n\rEl proveedor solo admite los articulos de la orden seleccionada");
               //    document.forms[0].elements['txtArticuloId'].value = '';
               //    document.forms[0].elements['txtArticuloId'].focus();
               //    return (true);
               //}
               //else {
               document.forms[0].action = "<%=strFormAction%>?strCmd=BuscarArticulo";
               document.forms[0].target = "ifrOculto";
               document.forms[0].submit();
               document.forms[0].target = '';
           //}
       }
   }

    if (parseInt(strCuenta) == 0) {
        document.forms[0].txtArticuloId.focus();
    }

    return (true);
}

function txtArticuloId_onfocus() {
    document.forms[0].txtArticuloId.select();
    return (true);
}

function txtCostoUnitario_onfocus() {
    document.forms[0].txtCostoUnitario.select();
    return (true);
}

function fnUpdArticuloPorIframe(strArticuloId, strDescripcionArticulo, strCostoReposicion, intError) {

    document.forms(0).txtArticuloId.value = strArticuloId;
    document.forms(0).hdnArticuloEncontradoId.value = document.forms(0).txtArticuloId.value;
    document.forms(0).txtDescripcionArticulo.value = strDescripcionArticulo;
    document.forms(0).txtCostoReposicion.value = strCostoReposicion;

    if (intError != 0) {
        alert('Artículo no encontrado.');
        document.forms(0).txtArticuloId.focus();
    }

}

function fnUpAgregarEliminarArticulo(intAccion, strRecordBrowserHTML, intError) {
    document.all.divDetalle.innerHTML = strRecordBrowserHTML;

    if (document.forms(0).txtArticulosLista.value == 0) {
        document.all.divBotones.style.display = 'none';
    }
    else {
        document.all.divBotones.style.display = '';
    }

    if (intError == 0) {
        document.forms(0).txtArticuloId.value = '';
        document.forms(0).txtDescripcionArticulo.value = '';
        document.forms(0).txtCostoReposicion.value = '';

        document.forms(0).txtCantidad.value = '';
        document.forms(0).txtCostoUnitario.value = '0';
    }
    else {
        if (intAccion == 1) { // Agregar Articulo
            alert("ERROR, Articulo no pudo Agregarse");
        }
        if (intAccion == 2) { // Eliminar Articulo
            alert("ERROR, Articulo no pudo Eliminarse");
        }
    }

    document.forms(0).txtArticuloId.focus();
}
    
// Elimina el Articulo seleccionado del detalle de los Insumos de Materia Prima
function intEliminaRegistro(intArticuloEliminar) {
    document.forms[0].action = "<%=strFormAction%>?strCmd=EliminarArticulo&intArticuloEliminarId=" + intArticuloEliminar;
    document.forms[0].target = "ifrOculto";
    document.forms[0].submit();
    document.forms[0].target = '';
}

//Modifica los datos del header de la Factura reiniciando la captura de articulos
    function cmdRegresar_onclick() {

        window.location.href = "MercanciaCapturarInsumosMateriaPrima.aspx?strCmd=ModificarDatos";

        return (true);
    }

// Agrega el Articulo capturado al detalle de la Compra Directa
function cmdAgregar_onclick() {

    var valida = true;
    var strCostoUnitario;

    if (document.forms(0).txtArticuloId.value != document.forms(0).hdnArticuloEncontradoId.value) {

        alert("Capturar correctamente el articulo a ingresar");
        document.forms[0].txtArticuloId.focus();
        return (false);
    }

    // Validamos que la cantidad sea un campo entero
    if (valida) { valida = blnValidarCampo(document.forms['frmMercanciaCapturarDetalleInsumosMateriaPrima'].elements['txtCantidad'], true, "Cantidad", cintTipoCampoEntero, 20, 1, ""); }

    if (!valida) {
        return (valida);
    }

    // Cantidad que sea mayor a cero
    if (parseInt(document.forms['frmMercanciaCapturarDetalleInsumosMateriaPrima'].elements['txtCantidad'].value) <= 0) {
        alert("Capturar correctamente la cantidad.");
        document.forms[0].txtCantidad.focus();
        return (false);
    }


    // Validacion del costo del articulo si esta configurada su captura
    if (document.forms[0].elements['hdnCapturaCosto'].value == 1) {
    
        // Verificar que se capturo costo
        if (valida) {
            valida = blnValidarCampo(document.forms['frmMercanciaCapturarDetalleInsumosMateriaPrima'].elements["txtCostoUnitario"], true, "Costo Unitario", cintTipoCampoCadenaDefinida, 20, 1, ".0123456789");
        }

        if (!valida) {
            return (valida);
        }

        // Verificamos que no tenga mas de 2 puntos     
        strCostoUnitario = document.forms[0].txtCostoUnitario.value;
        intCuenta = fnBuscaPuntoDecimal(strCostoUnitario);

        if (parseInt(intCuenta) > 1) {
            alert("Capturar correctamente el costo unitario.");
            document.forms[0].txtCostoUnitario.focus();
            return (false);
        }

        // CostoUnitario que sea mayor a cero
        if (parseFloat(document.forms[0].elements["txtCostoUnitario"].value) <= 0) {
            alert("Capturar correctamente el costo unitario.");
            document.forms[0].txtCostoUnitario.focus();
            return (false);
        }

        // Validamos contra los margenes establecidos
        fltMargenInferiorCompra = document.forms[0].txtMargenInferior.value;
        fltMargenSuperiorCompra = document.forms[0].txtMargenSuperior.value;

        fltCostoReposicion = document.forms[0].txtCostoReposicion.value;

        fltMargenInferior = parseFloat(fltCostoReposicion) * parseFloat(fltMargenInferiorCompra);

        fltMargenSuperior = parseFloat(fltCostoReposicion) * parseFloat(fltMargenSuperiorCompra);

        fltCostoUnitario = document.forms[0].txtCostoUnitario.value;
        fltCostoUnitario = strEliminacommas(fltCostoUnitario);

        fltMargenMinimo = parseFloat(fltCostoReposicion) - parseFloat(fltMargenInferior);
        fltMargenMaximo = parseFloat(fltCostoReposicion) + parseFloat(fltMargenSuperior);

        if (!((parseFloat(fltMargenMinimo) <= parseFloat(fltCostoUnitario)) && (parseFloat(fltCostoUnitario) <= parseFloat(fltMargenMaximo)))) {

            alert("Costo unitario del artículo fuera del margen.");
            document.forms[0].txtCostoUnitario.focus();
            return (false);
        }
    }
    else { // Validar que exista coto de reposicion para el articulo capturado
        if (parseFloat(document.forms[0].txtCostoReposicion.value) == 0) {

            alert("Articulo sin Costo de Reposición");
            document.forms[0].txtArticuloId.focus();
            return (false);
        }
        document.forms[0].txtCostoUnitario.value = document.forms[0].txtCostoReposicion.value;
    }

    document.forms[0].action = "<%=strFormAction%>?strCmd=AgregarArticulo";
    document.forms[0].target = "ifrOculto";
    document.forms[0].submit();
    document.forms[0].target = '';

    return (true);

}

// Cancelar captura compra directa
    function cmdCancelar_onClick() {

        if (confirm("Cancelar la Captura de los Insumos de Materia Prima?")) {

            window.location.href = "MercanciaCapturarInsumosMateriaPrima.aspx";
        }

        return (true);
    }

    function cmdImprimeCostos_onClick() {

        if (window.print) {

            document.ifrPageToPrint.document.all.ToPrintHtmContenido.innerHTML = document.all.divDetalle.innerHTML;
            document.ifrPageToPrint.focus();
            window.print();
        }
        else {
            alert("Tu navegador no soporta la función: Print.")
        }
    }

// Modificar solo los Importes en pagina inicial
function cmdModificarDatos_onClick() {
    document.forms[0].action = "MercanciaCapturarInsumosMateriaPrima.aspx?strCmd=ModificarImporte";
    document.forms[0].submit();
    return (true);
}

// Registrar compra Directa
function cmdRegistrar_onClick() {

    fltImporteTotal = "<%=fltTotalFacturado%>";
    fltImporteTotal = strEliminacommas(fltImporteTotal);

    fltImporteTotalDetalle = document.forms[0].txtImporteTotal.value;
    fltImporteTotalDetalle = strEliminacommas(fltImporteTotalDetalle);

    intCantidadTotal = document.forms[0].txtCantidadTotal.value;
    intCifraControl = document.forms[0].txtCifraControl.value;

    var fltMargenFactura = 0;
    var strMargenFactura = "";

    if (document.forms[0].elements['hdnCapturaCosto'].value == 1) {
        fltMargenFactura = 1.00;
        strMargenFactura = "No coincide el total facturado vs el importe total del detalle";
    }
    else {
        if (intCantidadTotal != intCifraControl) {
            alert("Cifra control incorrecta");
            document.forms[0].txtCifraControl.focus();
            return (true);
        }

        fltMargenFactura = parseFloat(document.forms[0].elements['hdnMargenFactura'].value);
        strMargenFactura = "La diferencia de costo excede lo permitido \r Revisar contra factura";
    }

    if (Math.abs(parseFloat(fltImporteTotal) - parseFloat(fltImporteTotalDetalle)) > fltMargenFactura) {
        alert(strMargenFactura);
    }
    else {

        document.forms[0].action = "<%=strFormAction%>?strCmd=RegistrarCompra";
        document.forms[0].target = "ifrOculto";
        document.forms[0].submit();
        document.forms[0].target = '';
   }

    return (true);
}

// Despliega el Folio asignado a la Factura de Insumos
    function fnUpRegistrarFacturaInsumos(intFolioFactura, intError) {

        if (intError == 0) {

        document.forms(0).txtIntFolioCDI.value = intFolioFactura;
        alert("Factura de Insumos de Materia Prima Registrada con el Folio : [" + intFolioFactura + "]");

        strParametros = '?intFacturaId=' + document.forms[0].txtFacturaId.value;
        strParametros = strParametros + '&hdnProveedorId=' + document.forms[0].hdnProveedorId.value;
        strParametros = strParametros + '&txtProveedorNombreId=' + document.forms[0].txtProveedorNombreId.value;
        strParametros = strParametros + '&txtRazonSocialProveedor=' + document.forms[0].txtRazonSocialProveedor.value;
        strParametros = strParametros + '&txtNumeroFactura=' + document.forms[0].txtNumeroFactura.value + document.forms[0].txtNumeroFacturaRuta.value;
        strParametros = strParametros + '&txtFechaFactura=' + document.forms[0].txtFechaFactura.value;
        strParametros = strParametros + '&txtFechaRecepcion=' + document.forms[0].txtFechaRecepcion.value;
        strParametros = strParametros + '&txtTotalFacturado=' + '<%=fltTotalFacturado%>';

            window.location.href = "MercanciaInsumosMateriaPrimaConfirmada.aspx" + strParametros;
    }
    else {
        if (intError == -97) {
            alert("El impuesto de los articulos no corresponde al indicado");
        }
        if (intError == -98) {
            alert("Los articulos del detalle no tienen impuesto y se indico un impuesto");
        }
        if (intError == -99) {
            alert("Hay articulos del detalle con impuesto y se indico impuesto 0");
        }
        if (intError == -100) {
            alert("La factura ya esta registrada");
        }
        if (intError == -110) {
            alert("Un articulo no esta en plano para la sucursal");
        }
        if (intError == -120) {
            alert("Ocurrio un error");
        }
        if (intError == -1000) {
            alert("No se registro la compra, verifique los datos y reintente");
        }
    }
}

function window_onload() {
    document.forms[0].action = "<%=strFormAction%>";
    document.all.divDetalle.innerHTML = "<%=strRecordBrowserHTML%>";

    if (document.forms[0].elements['hdnCapturaCosto'].value == 1) {
        
        document.all.txtCostoUnitario.style.display = '';
        document.all.tblCifraControl.style.display = 'none';
    }
    else {
        
        document.all.txtCostoUnitario.style.display = 'none';
        document.all.tblCifraControl.style.display = '';
        document.all.txtCostoUnitario.value = '0';
    }

    if (document.forms(0).txtArticulosLista.value == 0) {
        document.all.divBotones.style.display = 'none';
    }
    else {
        document.all.divBotones.style.display = '';
    }

    document.forms[0].txtArticuloId.focus();
    return (true);
}

    function txtCostoUnitario_onKeyDown() {

        if (event.keyCode == 13) {

            document.forms[0].elements['cmdAgregar'].focus();
        }

        if (event.keyCode == 9) {

            document.forms[0].elements['cmdAgregar'].click();
            return (false);
        }
    }

    function txtCantidad_onKeyDown() {
        
        if (event.keyCode == 13) {
            
            if (document.forms[0].elements['hdnCapturaCosto'].value == 1) {

                document.forms[0].elements['txtCostoUnitario'].focus();
            }
            else {

                document.forms[0].elements['cmdAgregar'].focus();
            }
        }
    }

//-->
</script>
</HEAD>
<body leftMargin="0" topMargin="0" onload="return window_onload()" marginwidth="0" marginheight="0">
<form name="frmMercanciaCapturarDetalleInsumosMateriaPrima" action="about:blank" method="post">
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
            <td width="10" bgColor="#ffffff"> <img height="8" src="../static/images/pixel.gif" width="10"></td>
            <td class="tdmigaja" width="583"><span class="txdmigaja">Está en : 
              </span> <a class="txdmigaja" href="Mercancia.aspx">Mercancía</a> 
              <span class="txdmigaja">: <a class="txdmigaja" href="MercanciaEntradas.aspx"> 
              Entradas</a></span> <span class="txdmigaja">: </span> <span class="txdmigaja"></span><span class="txdmigaja"> 
              <a class="txdmigaja" href="MercanciaEntradasComprasDirectas.aspx"> 
              Compras directas </a> </span><span class="txdmigaja">: </span> <span class="txdmigaja"></span><span class="txdmigaja"></span> 
              <span class="txdmigaja">Capturar insumos de materia prima</span></td>
            <td class="tdfechahora" width="182"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td vAlign="top" width="583"> <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                <tr> 
                  <td class="tdtablacont" vAlign="top" width="100%"> <table width="100%" cellSpacing="0" cellPadding="0" border="0">
                      <tr> 
                        <td class="tdtittablas3" vAlign="middle" align="right" width="80%">Insumos Materia Prima Folio: </td>
                        <td class="txtitintabla" vAlign="middle" width="20%"><input class="campotabladeshabilitado" readOnly type="text" size="16" name="txtIntFolioCDI"></td>
                      </tr>
                    </table>
                    <br> <table class="tdenvolventetablas" width="100%">
                      <tr> 
                        <td class="tdtittablas3" align="left" width="20%">Proveedor</td>
                        <td class="tdtittablas3" align="left" width="60%">Razon 
                          Social</td>
                        <td class="tdtittablas3" align="left" width="20%"><%--Orden--%></td>
                      </tr>
                      <TR> 
                        <td class="campotablaresultadoenvolventeazul" align="left" width="20%"><script language="JavaScript">strProveedorNombreId()</script></td>
                        <td class="campotablaresultadoenvolventeazul" align="left" width="60%"><script language="JavaScript">strRazonSocialProveedor()</script></td>
                        <td class="campotablaresultadoenvolventeazul" align="left" width="20%"></td>
                      </TR>
                    </table>
                    <br> <table class="tdenvolventetablas" width="100%">
                      <tr> 
                        <td class="tdtittablas3" align="left" width="30%">No Factura</td>
                        <td class="tdtittablas3" align="left" width="20%">Fecha 
                          Factura</td>
                        <td class="tdtittablas3" align="left" width="20%">Fecha 
                          Recepción</td>
                        <td class="tdtittablas3" align="left" width="20%">Total 
                          Facturado</td>
                      </tr>
                      <TR> 
                        <td class="campotablaresultadoenvolventeazul" align="left" width="30%"><script language="JavaScript">strNumeroFactura()</script></td>
                        <td class="campotablaresultadoenvolventeazul" align="left" width="20%"><script language="JavaScript">dtmFechaFactura()</script></td>
                        <td class="campotablaresultadoenvolventeazul" align="left" width="20%"><script language="JavaScript">strFechaRecepcion()</script></td>
                        <td class="campotablaresultadoenvolventeazul" align="left" width="20%"><script language="JavaScript">fltTotalFacturado()</script></td>
                      </TR>
                    </table>
                    <span class="txsubtitulo"><br>
                    <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Detalles 
                    Compra<br>
                    <div id="divDetalle" name="divDetalle"></div>
                    </span> <br> <table class="tdenvolventetablas" width="100%" >
                      <tr> 
                        <td class="tdtittablas3" align="left" width="30%">Código</td>
                        <td class="tdtittablas3" align="left" width="10%">Cantidad</td>
                        <td class="tdtittablas3" align="left" width="10%">Costo 
                          unitario</td>
                        <td class="tdtittablas3" align="left"  width="30%">Descripción</td>
                        <td class="tdtittablas3" align="center" width="20%" vAlign="middle"  rowspan="2" > 
                          <input class="boton" id="cmdAgregar" onclick="return cmdAgregar_onclick()" type="button"
																value="Agregar" name="cmdAgregar"> 
                        </td>
                      </tr>
                      <tr> 
                        <td align="left" width="30%" class="txtitintabla"> <input class="campotablahabilitadoderecha" id="txtArticuloId" onkeydown="if(event.keyCode==13){document.forms[0].elements['txtCantidad'].focus();}"
																onfocus="return txtArticuloId_onfocus()" type="text" maxLength="16" size="16" name="txtArticuloId"
																autocomplete="off"> 
                          <a id="objLupa2" onclick="return objLupa2Articulo_onClick();" href="javascript:;"> 
                          <img height="17" src="../static/images/icono_lupa.gif" width="16" align="absMiddle" border="0"></a></td>
                        <td class="tdpadleft5" vAlign="middle" align="left" width="10%"> 
                          <input class="campotablahabilitadoderecha" id="txtCantidad" onkeydown="return txtCantidad_onKeyDown()"
																onfocus="return txtCantidad_onfocus()" type="text" maxLength="8" size="12" name="txtCantidad"
																autocomplete="off"> 
                        </td>
                        <td class="tdpadleft5" vAlign="middle" align="left" width="10%"><input class="campotablahabilitadoderecha" id="txtCostoUnitario" onkeydown="return txtCostoUnitario_onKeyDown()"
																onfocus="return txtCostoUnitario_onfocus()" type="text" maxLength="16" size="12" name="txtCostoUnitario" autocomplete="off"> 
                        </td>
                        <td class="txtitintabla" vAlign="middle" > <input class="campotablaresultadoenvolventeazul" readOnly type="text" size="30" name="txtDescripcionArticulo"> 
                        </td>
                      </tr>
                    </table>
                    <br> <table class="tdenvolventetablas" width="100%" id="tblCifraControl">
                      <tr> 
                        <td class="tdtittablas3" align="right"   width="90%">Cifra 
                          Control:&nbsp; <input class="campotablahabilitadoderecha" id="txtCifraControl" onKeyDown="if(event.keyCode==13){document.forms[0].elements['cmdRegistrar'].focus();} if(event.keyCode==9){document.forms[0].elements['cmdRegistrar'].click(); return(false);}" type="text" maxlength="03" size="03" name="txtCifraControl" autocomplete="off"></td>
                        <td class="tdpadleft5" align="left"   width="10%">&nbsp;</td>
                      </tr>
                    </table>
                    <br> <table width="100%" cellSpacing="0" cellPadding="0" border="0">
                      <tr> 
                        <td> <input class="boton" id="cmdRegresar" onClick="return cmdRegresar_onclick()" type="button"
																value="Regresar" name="cmdRegresar"></td>
                        <td> <div id="divBotones" style="DISPLAY: none">&nbsp; 
                            <input name='cmdCancelar' type='button' class='boton' id='cmdCancelar' value='Cancelar'
																	onClick='return cmdCancelar_onClick()'>
                            &nbsp; 
                            <input name='cmdImprimeCostos' type='button' class='boton' id='cmdImprimeCosto' value='Imprimir Detalle'onClick='return cmdImprimeCostos_onClick()'>
                            &nbsp; 
                            <input name='cmdModificar' type='button' class='boton' id='cmdModificar' value='Modificar importes'
																	onClick='return cmdModificarDatos_onClick()'>
                            &nbsp; 
                            <input name='cmdRegistrar' type='button' class='boton' id='cmdRegistrar' value='Registrar compra'
																	onClick='return cmdRegistrar_onClick()'>
                          </div></td>
                      </tr>
                    </table></td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          </tr>
          <tr> 
            <td class="tdbottom" colSpan="2"><script language="JavaScript">crearTablaFooter()</script></td>
          </tr>
        </table></td>
    </tr>
  </table>
  <tr> 
    <input type='hidden' value='<%=Request.Form("txtFacturaId")%>' name='txtFacturaId'>
    <input type='hidden' value='<%=Request.Form("txtMargenInferior")%>' name='txtMargenInferior'>
    <input type='hidden' value='<%=Request.Form("txtMargenSuperior")%>' name='txtMargenSuperior'>
    <input type='hidden' value='<%=Request.Form("hdnProveedorId")%>' name='hdnProveedorId'>
    <input type='hidden' value='<%=Request.Form("hdnProveedorNombreId")%>' name='hdnProveedorNombreId'>
    <input type='hidden' value='<%=Request.Form("txtProveedorNombreId")%>' name='txtProveedorNombreId'>
    <input type='hidden' value='<%=Request.Form("txtRazonSocialProveedor")%>' name='txtRazonSocialProveedor'>
    <input type='hidden' value= '<%=Request.Form("hdnCapturaCosto")%>' name='hdnCapturaCosto' >
    <input type='hidden' value= '<%=Request.Form("hdnMargenFactura")%>' name='hdnMargenFactura' >
    <input type='hidden' value='<%=Request.Form("txtRFC")%>' name='txtRFC'>
    <input type='hidden' value='<%=Request.Form("txtRFCOculto")%>' name='txtRFCOculto'>
    <input type='hidden' value='<%=Request.Form("txtNumeroFactura")%>' name='txtNumeroFactura'>
    <input type='hidden' value='<%=Request.Form("txtNumeroFacturaRuta")%>' name='txtNumeroFacturaRuta'>
    <input type='hidden' value='<%=Request.Form("txtFechaRecepcion")%>' name='txtFechaRecepcion'>
    <input type='hidden' value='<%=Request.Form("txtFechaFactura")%>' name='txtFechaFactura'>
    <input type='hidden' value='<%=Request.Form("cboIvaAplicado")%>' name='cboIvaAplicado'>
    <input type='hidden' value='<%=Request.Form("cboDescuento")%>' name='cboDescuento'>
    <input type='hidden' value='<%=Request.Form("chkAntesdeIva")%>' name='chkAntesdeIva'>
    <input type='hidden' value='<%=Request.Form("chkDespuesdeIva")%>' name='chkDespuesdeIva'>
    <input type='hidden' value='<%=Request.Form("txtSumaProductos")%>' name='txtSumaProductos'>
    <input type='hidden' value='<%=Request.Form("txtDescuentoAntesdeIva")%>' name='txtDescuentoAntesdeIva'>
    <input type='hidden' value='<%=Request.Form("txtTotalFacturado")%>' name='txtTotalFacturado'>
    <input type='hidden' value='<%=Request.Form("txtImporteIEPS")%>' name='txtImporteIEPS'>
    <input type='hidden' value='<%=Request.Form("txtIvaFacturado")%>' name='txtIvaFacturado'>
    <input type='hidden' value='<%=Request.Form("txtIvaDescuento")%>' name='txtIvaDescuento'>
    <input type='hidden' value='<%=Request.Form("txtDescuentoDespuesdeIva")%>' name='txtDescuentoDespuesdeIva'>
    <input type='hidden' value='<%=Request.Form("txtTotalNetoFacturado")%>' name='txtTotalNetoFacturado'>
    <input type='hidden' value='<%=Request.Form("txtCostoReposicion")%>' name='txtCostoReposicion'>
    <input type='hidden' value='<%=Request.Form("hdnArticuloEncontradoId")%>' name='hdnArticuloEncontradoId'>
    <input type='hidden' value='<%=Request.Form("hdnArticuloAnteriorId")%>' name='hdnArticuloAnteriorId'>
  </tr>
  <script language="JavaScript">
	<!--
    new menu(MENU_ITEMS, MENU_POS);
    new menu(MENU_ITEMS2, MENU_POS2);
    //-->
			</script>
</form>
<iframe name="ifrOculto" src width="0" height="0"></iframe>
<iframe height="0" src="../static/PageToPrint.htm" width="0" name="ifrPageToPrint"></iframe>
</body>
</HTML>

<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="MercanciaCeroFaltantesNivelDeProductos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaCeroFaltantesNivelDeProductos" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>


<html>
<head>
    <title>Sistema Administrador de Sucursal</title>

    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link rel="stylesheet" href="../static/css/menu.css">
    <link rel="stylesheet" href="../static/css/menu2.css">
    <link rel="stylesheet" href="../static/css/estilo.css">
    <script language="JavaScript" src="../static/scripts/Tools.js"></script>
    <script language="JavaScript" src="../static/scripts/menu.js"></script>
    <script language="JavaScript" src="../static/scripts/menu_items.js"></script>
    <script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
    <script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
    <script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
    <script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
    <script language="JavaScript" id="clientEventHandlersJS"><!--

    function window_onload() {
        MM_preloadImages('../static/images/bsalir_on.gif', '../static/images/bayuda_on.gif');
        document.forms[0].action = "<%=strFormAction%>";

        //Se llenan los combos Division y Categoria.
        <%= LlenarControlDivisionArticulos() %>
        <%= LlenarControlCategoriaArticulos()%>

        //Validacion de codigo de producto
        var strErrorArticuloId = "<%=strErrorArticuloId%>";

        if (strErrorArticuloId == "1") {
            window.alert("Articulo no Valido.");
        }
        else {
            //Si el articulo es valido se muestra en pantalla.
                document.forms[0].elements['txtArticuloId'].value = "<%=intArticuloInternoId%>";
                document.forms[0].elements['txtArticuloDescripcion'].value = "<%=strArticuloInternoDescripcion%>";
		}
    }

    function strGetCustomDateTime() {
        document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
    return (true);
}


function frmMercanciaCeroFaltantesResumen_onsubmit() { 
    return (true);
}

function cmdRegresar_onclick() {
    //Redirecciona a usuario al "home" de Cero Faltantes.
    window.location = "MercanciaCeroFaltantes.aspx";

}

function txtArticuloId_onBlur(e) {
    if (document.getElementById('txtArticuloId').value == '')
    {
        document.getElementById('txtArticuloDescripcion').value = '';
    }
}

function txtArticuloId_onKeyPress(e) {

    //Se limpia la descripcion del articulo y se validan los caracteres permitidos.
    document.forms[0].elements['txtArticuloDescripcion'].value = '';

    var key = window.event ? e.keyCode : e.wich;

    //No se permiten caracteres especiales para el Articulo.
    if ((key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123) || (key == 32)) {
        return true;
    }
    else{
        return false;
    }
}

function txtStock_onKeyPress(e) {
    
    var key = window.event ? e.keyCode : e.wich;

    //Para el Stock solo se permiten literales numericas.
    if (key > 47 && key < 58) {
        return true;
    }
    else {
        return false;
    }
}

function Pop(url, width, height) {
    var Win = window.open(url, 'Pop', 'width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no');
    return false;
}

function cmdVerificarArticulo_onclick(url, width, height) {

    if (trim(document.forms[0].elements['txtArticuloId'].value) == '') {

        //Si el campo de producto esta vacio.
        alert('Por favor capture el código o descripción del producto.')
    }
    else {
        if (isNaN(document.forms[0].elements['txtArticuloId'].value)) {

            //Si la busqueda es por "Descripcion" de producto.
            url = url + '&strArticuloIdNombre=' + document.forms[0].elements['txtArticuloId'].value;
            
            //Llamada a metodo que muestra la descripcion de los productos.
            Pop(url, width, height);
        }
        else {

            //Si la busqueda es por "Codigo" de producto.
            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultarPorCodigo';
            document.forms[0].target = "ifrOculto";
            document.forms[0].submit();
        }
    }
}

        function cmdTodos_onfocus() {
            //Se limpian todos los campos del Stock.
            document.getElementById('txtMayorA').value = '';
            document.getElementById('txtMenorA').value = '';
            document.getElementById('cmdIgualA').value = '';
        }

        function txtMayorA_onfocus() {
            //Se selecciona la opcion "txtMayorA" y se limpian los demas campos.
            document.forms[0].elements["cmdMayorA"].checked = true;
            document.getElementById('txtMenorA').value = '';
            document.getElementById('txtIgualA').value = '';
}

function txtMenorA_onfocus() {
    //Se selecciona la opcion "txtMenorA" y se limpian los demas campos.
    document.forms[0].elements["cmdMenorA"].checked = true;
    document.getElementById('txtMayorA').value = '';
    document.getElementById('txtIgualA').value = '';
}

function txtIgualA_onfocus() {
    //Se selecciona la opcion "txtIgualA" y se limpian los demas campos.
    document.forms[0].elements["cmdIgualA"].checked = true;
    document.getElementById('txtMayorA').value = '';
    document.getElementById('txtMenorA').value = '';
}

function cmdVerificarAccion_onclick(id) {
    var intArticuloId = id.substring(3);
    var accion = id.substring(0, 3);
    
    //Se redirecciona al usuario a la pantalla del "Detalle".
    window.location = "MercanciaCeroFaltantesNivelDeProductosDetalle.aspx?intArticuloId=" + intArticuloId;	
}

function cmdConsultar_onclick() {

    //Variables.
    var valida = true;
    var IdArticulo = trim(document.getElementById('txtArticuloId').value);
    var DescripcionArticulo = trim(document.getElementById('txtArticuloDescripcion').value);
    var MayorA = trim(document.getElementById('txtMayorA').value);
    var MenorA = trim(document.getElementById('txtMenorA').value);
    var IgualA = trim(document.getElementById('txtIgualA').value);

    

    if ((IdArticulo == '' && DescripcionArticulo != '') || (IdArticulo != '' && DescripcionArticulo == '')) {

        //Se limpian los campos del articulo.
        document.getElementById('txtArticuloId').value = '';
        document.getElementById('txtArticuloDescripcion').value = '';

        valida = false;
        alert('Articulo no valido')
        return (false);
    }

    //Validacion de los filtros de Stock
    if (document.forms[0].elements["cmdTodos"].checked == false) {

        //Mayor A
        if ((document.forms[0].elements["cmdMayorA"].checked == true) && (MayorA == '')) {
            valida = false;
            alert('El valor de Mayor a es un campo requerido');
            return (false);
        }
        //Menor A    
        if ((document.forms[0].elements["cmdMenorA"].checked == true) && (MenorA == '')) {
            valida = false;
            alert('El valor de Menor a es un campo requerido');
            return (false);
        }
        //Igual A
        if ((document.forms[0].elements["cmdIgualA"].checked == true) && (IgualA == '')) {
            valida = false;
            alert('El valor de Igual a es un campo requerido');
            return (false);
        }
    }

    //Si la validacion fue correcta se ejecuta rutina en el servidor para la consulta.
    if (valida) {
        document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultar'
	    document.forms[0].target = "ifrOculto";
	    document.forms[0].submit();
	}

    return (valida)
}


        function trim(stringToTrim) {
            return stringToTrim.replace(/^\s+|\s+$/g, "");
        }

        function cmdImprimir_onclick() {

            //Validacion de resultados
            var tablaTotal = document.getElementById('tblCeroFaltantes').innerHTML
            if (trim(tablaTotal) == 'Consulta sin resultados' || trim(tablaTotal) == '') {
                alert('No hay resultados de la consulta')
                return (false);
            }

            document.forms[0].action = "<%=strFormAction%>?strCmd=Imprimir";
            document.forms[0].target = "ifrOculto";
            document.forms[0].submit();
            document.forms[0].target = '';

            return(true);
        }

        function fnImprimir(strCeroFaltantes) {

            //Llamada desde el servidor para imprimir resultados de las consulta.
            document.ifrPageToPrint.document.all.divContenido.innerHTML = strCeroFaltantes;
            document.ifrPageToPrint.focus();
            window.print();

        }

//-->
</script>

    <style type="text/css">
        .auto-style1 {
            width: 4px;
        }
    </style>

</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaCeroFaltantesResumen" onSubmit="return frmMercanciaCeroFaltantesResumen_onsubmit()">
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
            <td width="10" bgcolor="#ffffff"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja">
                <span class="txdmigaja">Está en : 
                </span>
                <a href="Mercancia.aspx" class="txdmigaja">Mercancía</a>
                <span class="txdmigaja"> 
                : Cero Faltantes
                </span>
            </td>
            <td width="182" class="tdfechahora">
                <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont">
                <script language="JavaScript">crearDatosSucursal()</script><br />
                <span class="txtitulo">
                    <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle">
                    Cero Faltantes
                </span> 
                <table  width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="tdtittablas">Artículo</td>
                        <td class="tdpadleft5">
                            <input onblur="txtArticuloId_onBlur();" onKeyPress=" return txtArticuloId_onKeyPress(event);" id="txtArticuloId" class="campotabla" maxLength="14" size="14" name="txtArticuloId"> 
                                <A href="javascript:cmdVerificarArticulo_onclick('PopArticulo.aspx?strArticulo=txtArticuloId&amp;strArticuloNombreId=txtArticuloDescripcion',400,540)">
							        <IMG border="0" align="absMiddle" src="../static/images/icono_lupa.gif" width="17" height="17">
							    </A>
                            <input class="campotablaresultado" readOnly size="45" name="txtArticuloDescripcion">

                        </td>
                    </tr>
                    
                </table> 
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="tdtittablas" style="width: 4px">
                            Stock
                        </td>
                        <td class="tdtittablas" style="width: 61px">
                            <input type="radio" id="cmdTodos" name="cmdFiltroStock" value="0" checked onfocus="return cmdTodos_onfocus()"/>Todos
                        </td>
                        <td class="tdtittablas" style="width: 68px">
                            <input type="radio" id="cmdMayorA" name="cmdFiltroStock" value="1" onfocus="return txtMayorA_onfocus()"/>Mayor a
                        </td>
                        <td class="tdpadleft5" style="width: 43px">
                            <input id="txtMayorA" name="txtMayorA"  onKeyPress="return txtStock_onKeyPress(event);" onfocus="return txtMayorA_onfocus()" type="text" class="campotabla" maxLength="4" size="2"/>
                        </td>
                        <td class="tdtittablas" style="width: 121px">División Jerárquica</td>
                        <td class="tdpadleft5">    <select id="cboDivisionArticulos" name="cboDivisionArticulos" class="campotabla" style="width:190px">
																<option selected="selected" value="0">&raquo; Todas &laquo;</option>
															</select>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdtittablas" colspan="2">
                        </td>
                        <td  class="tdtittablas" style="width: 68px">
                            <input type="radio" id="cmdMenorA" name="cmdFiltroStock" value="2" onfocus="return txtMenorA_onfocus()"/>Menor a
                        </td>
                        <td class="tdpadleft5" style="width: 43px">
                            <input id="txtMenorA" name="txtMenorA" onKeyPress="return txtStock_onKeyPress(event);" onfocus="return txtMenorA_onfocus()" type="text" class="campotabla" maxLength="4" size="2"/>
                        </td>
                        <td class="tdtittablas" style="width: 121px">Categoría Operativa</td>
                        <td class="tdpadleft5">    <select id="cboCategoriaArticulos" class="campotabla" name="cboCategoriaArticulos" class="campotabla" style="width:190px">
																<option selected="selected" value="0">&raquo; Todas &laquo;</option>
															</select>
                        </td>
                    </tr>
                     <tr>
                        <td class="tdtittablas" colspan="2">
                        </td>
                            <td class="tdtittablas" style="width: 68px">
                            <input type="radio" id="cmdIgualA" name="cmdFiltroStock" value="3" onfocus="return txtIgualA_onfocus()"/>Igual a
                        </td>
                        <td class="tdpadleft5" style="width: 43px">
                            <input id="txtIgualA" name="txtIgualA" onKeyPress="return txtStock_onKeyPress(event);" onfocus="return txtIgualA_onfocus()" type="text" class="campotabla" maxLength="4" size="2"/>
                        </td>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <input id="cmdConsultar" name="cmdConsultar" type="button" class="boton" value="Consultar" onClick="return cmdConsultar_onclick()" style="margin-top:20px;">
                        </td>
                    </tr>
                </table>
              <br> <div id="tblResultados" class="tdconttablasrojo"></div>
                   <div id="tblCeroFaltantes" style="width:100%"></div>
              <br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()">
                   <input id="cmdImprimir" name="cmdImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick()">&nbsp;
              <br> <br> </td>
            <td width="187" rowspan="2" valign="top" class="tdcolumnader">
                 
            </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
    new menu(MENU_ITEMS, MENU_POS);
    new menu(MENU_ITEMS2, MENU_POS2);

    
    //-->
			</script>
</form>
    <div style="display:none;">
        <div id="divConsultaCeroFaltantes">
            <%= Me.strTablaConsultaResumenCeroFaltantes()%>
        </div>            
        <div id="divCodigoArticulo">
            <%= Me.strTablaConsultaCodigoArticulo()%>
        </div>
        </div>
    
    
    <iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrPaginaenBlanco.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</html>

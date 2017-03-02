<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MercanciaCapturarCaducidadArticulos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlCaducidadArticulos" %>
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
    <script language="JavaScript" id="clientEventHandlersJS">
<!--
        function window_onload() {
            MM_preloadImages('../static/images/bsalir_on.gif', '../static/images/bayuda_on.gif');
            document.forms[0].action = "<%=strFormAction%>";

            var intFolioId = '<%= strFolioId()%>';

            parent.document.getElementById('txtFolioId').value = intFolioId;
            parent.document.getElementById('txtArticuloId').focus();

            var cmd = '<%=strCmd()%>';
            if (trim(cmd) == "cmdAgregar") {

                parent.document.getElementById('txtArticuloId').value = '';
                parent.document.getElementById('txtExistencia').value = '';
                parent.document.getElementById('txtDescripcionArticulo').value = '';
                parent.document.getElementById('txtIdMes').value = '';
                parent.document.getElementById('txtDescripcionMes').value = '';
            }
        }
        
        function strGetCustomDateTime() {
            document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
                return (true);
        }

        function frmMercanciaCapturarCaducidadArticulos_onsubmit() {
            return (true);
        }

        function cmdRegresar_onclick() {
            window.location.href = "Mercancia.aspx";
        }

        function txtRazon_onKeyPress(e) {
            var key = window.event ? e.keyCode : e.wich;

            if (document.getElementById('chkImplementado').checked == true) {
                return (false);
            }
            //No se permiten caracteres especiales para el Articulo.
            if ((key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123) || (key == 32)) {
                return true;
            }
            else {
                return false;
            }
        }

        //Guarda la razon por la cual no se implemento
        function cmdGuardar_onclick() {

            if (trim(document.getElementById('tblResultados').innerHTML) == '') {
                return (false);
            }
            else {

                var confirmacion = confirm('Desea guardar la informacion?')

                if (confirmacion == true) {

                    document.forms[0].action = '<%=strThisPageName%>?strCmd=cmdGuardar' //&intExhibicionCodigo=' + intExhibicionCodigo;//"<= strCodigoExhibicionId()%>";
                    document.forms[0].target = "ifrOculto";
                    document.forms[0].submit();
                    return (true);
                }
            }
        }

        function trim(stringToTrim) {
            return stringToTrim.replace(/^\s+|\s+$/g, "");
        }

        function cmdLimpiarCampos_onclick() {

            document.getElementById('txtArticuloId').value = '';
            document.getElementById('txtExistencia').value = '';
            document.getElementById('txtDescripcionArticulo').value = '';
            document.getElementById('txtIdMes').value = '';
            document.getElementById('txtDescripcionMes').value = '';
            document.getElementById('tblResultados').innerHTML= '';

            document.forms[0].action = "<%=strFormAction%>?strCmd=cmdEliminarLista";
            document.forms[0].target = "ifrOculto";
            document.forms[0].submit();
            document.forms[0].target = '';
        }

        function objLupaArticulo_onclick() {

            if (trim(document.getElementById('txtArticuloId').value) == '') {
                return (false);
            }

            txtArticuloId_onblur();
        }

        function txtArticuloId_onblur() {
            

            if (trim(document.forms[0].elements['txtArticuloId'].value) == '') {
                document.forms[0].elements['txtArticuloId'].value = '';
                document.forms[0].elements['hdnArticuloId'].value = '';       
                document.forms[0].elements['txtDescripcionArticulo'].value = '';
                return;
            }

                objArticuloLupa_onClick();
        }

        // Agrega el Articulo al detalle
        function intAgregaRegistro() {
            document.forms[0].action = "<%=strFormAction%>?strCmd=cmdAgregar" //&intArticuloAgregarId=" + document.forms[0].elements['txtArticuloId'].value;
            document.forms[0].target = "ifrOculto";
            document.forms[0].submit();
            document.forms[0].target = '';
        }

        function cmdAgregar_onclick() {

            //Campos
            var idArticulo = trim(document.getElementById('txtArticuloId').value);
            var Existencia = trim(document.getElementById('txtExistencia').value);
            var DescripcionArticulo = trim(document.getElementById('txtDescripcionArticulo').value);
            var Mes = trim(document.getElementById('txtIdMes').value);


            if (validaCampos(idArticulo, Existencia, DescripcionArticulo, Mes) == false) { return (false); }
            else {
                intAgregaRegistro();
            }
        }

        function validaCampos(idArticulo, Existencia, DescripcionArticulo, Mes) {

            if (idArticulo == '') { alert('El campo "Código" es obligatorio'); document.forms[0].elements['txtArticuloId'].focus(); return (false); }
            else if (Existencia == '') { alert('El campo "Existencia" es obligatorio'); document.getElementById('txtExistencia').focus(); return (false); }
            else if (DescripcionArticulo == '') { alert('El campo "Descripción" es obligatorio'); document.getElementById('txtArticuloId').focus(); return (false); }
            else if (Existencia == '0') { alert('El campo "Existencia" debe ser mayor a 0'); document.getElementById('txtExistencia').focus(); return (false); }
            else if (Mes == '0' || Mes == '') { alert('El campo "Mes de Caducidad" es obligatorio'); document.getElementById('txtIdMes').focus(); return (false); }
            else { return (true);}
        }

        function Pop(url, width, height) {
            var Win = window.open(url, 'Pop', 'width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no');
            return (false);
        }

        function objArticuloLupa_onClick() {

            if (document.forms[0].elements['txtArticuloId'].value != "") {
                
                if (!isNaN(document.forms[0].elements['txtArticuloId'].value)) {
                
                    // Es un numero
                    if (document.forms[0].elements['txtArticuloId'].value != '0') {
                
                        document.forms[0].action = "<%=strFormAction%>?strCmd=BuscarArticulo";
                        document.forms[0].target = "ifrOculto";
                        document.forms[0].submit();
                        document.forms[0].target = '';
                        return (true);
           }
       }
       else {
                
           // Es una descripcion
           document.forms[0].elements['txtDescripcionArticulo'].value = '';

           strEvalJs = "opener.objArticuloLupa_onClick();";
           strParametros = '';
           strParametros = strParametros + '?strArticuloIdNombre=' + document.forms[0].elements['txtArticuloId'].value;
           strParametros = strParametros + '&strArticuloNombreId=txtDescripcionArticulo'
           strParametros = strParametros + '&strArticulo=txtArticuloId'
           Pop('PopArticulo.aspx' + strParametros + '&strEvalJs=' + strEvalJs, 500, 540);
       }
   }
   else {
       alert("Teclear número de artículo o descripción");
       document.forms(0).txtArticuloId.focus();
       return (false);
   }
        }

        function fnUpAccionInventarios(intAccion, intArticuloBuscadoId, strArticuloBuscadoDescripcion, intResultadoAccion) {
            
            if (intAccion == 0) {

                // Busqueda de Articulo   
                if (intResultadoAccion == 1) {
                    document.forms[0].elements['txtArticuloId'].value = intArticuloBuscadoId;
                    document.forms[0].elements['txtDescripcionArticulo'].value = strArticuloBuscadoDescripcion;
                    document.forms[0].elements['txtExistencia'].focus();
                }
                else {
                    alert("El Código del Artículo no fue encontrado");
                    document.forms[0].elements['txtArticuloId'].focus();
                }
            }

            if (intAccion == 1) {

                // Agregar Articulo   
                if (intResultadoAccion == -100) {
                    alert("Error Fatal al agregar el Código del Artículo.");
                }
                if (intResultadoAccion == -120) {
                    alert("El Código del Artículo no es un número válido.");
                }
                if (intResultadoAccion == -121) {
                    alert("El valor de la Existencia no es un número válido.");
                }
                
                
                document.forms[0].elements['txtArticuloId'].focus();
            }
        }

        function txtArticuloId_onKeyPress(e) {

            //Se limpia la descripcion del articulo y se validan los caracteres permitidos.
            document.forms[0].elements['txtDescripcionArticulo'].value = '';

            var key = window.event ? e.keyCode : e.wich;

            if (key == 13) {
                if (trim(document.forms[0].elements['txtArticuloId'].value) == '') {
                    return (false);
                }
                txtArticuloId_onblur();
                return (true);
            }
                //No se permiten caracteres especiales para el Articulo.
            else if ((key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123) || (key == 32)) {
                return true;
            }
            else {
                return false;
            }
        }

        function txtExistencia_onKeyPress(e) {

            var key = window.event ? e.keyCode : e.wich;

            if (key == 13) {
                if (trim(document.getElementById('txtExistencia').value) == '') {
                    return (false);
                }
            else{
                document.forms[0].elements['txtIdMes'].focus();
                return (true);
            }
            }
                //No se permiten caracteres especiales para el Articulo.
            else if (key > 47 && key < 58) {
                return true;
            }
            else {
                return false;
            }
        }

        function txtMesId_onKeyPress(e) {

            //Se limpia la descripcion del articulo y se validan los caracteres permitidos.
            document.forms[0].elements['txtDescripcionMes'].value = '';

            var key = window.event ? e.keyCode : e.wich;

            if (key == 13) {
                txtIdMes_onblur();
                cmdAgregar_onclick();
                return (true);
            }
                //No se permiten caracteres especiales para el Articulo.
            else if (key > 47 && key < 58) {
                return true;
            }
            else {
                return false;
            }
        }

        function txtIdMes_onblur() {
            var IdMes = trim(document.getElementById('txtIdMes').value);
            

            if (IdMes.length > 0 && IdMes.length < 3) {

                switch (IdMes){ 
                    case '1':
                        document.getElementById('txtDescripcionMes').value = 'ENERO';
                        return;
                    case '2':
                        document.getElementById('txtDescripcionMes').value = 'FEBRERO';
                        return;
                    case '3':
                        document.getElementById('txtDescripcionMes').value = 'MARZO';
                        return;
                    case '4':
                        document.getElementById('txtDescripcionMes').value = 'ABRIL';
                        return;
                    case '5':
                        document.getElementById('txtDescripcionMes').value = 'MAYO';
                        return;
                    case '6':
                        document.getElementById('txtDescripcionMes').value = 'JUNIO';
                        return;
                    case '7':
                        document.getElementById('txtDescripcionMes').value = 'JULIO';
                        return;
                    case '8':
                        document.getElementById('txtDescripcionMes').value = 'AGOSTO';
                        return;
                    case '9':
                        document.getElementById('txtDescripcionMes').value = 'SEPTIEMBRE';
                        return;
                    case '10':
                        document.getElementById('txtDescripcionMes').value = 'OCTUBRE';
                        return;
                    case '11':
                        document.getElementById('txtDescripcionMes').value = 'NOVIEMBRE';
                        return;
                    case '12':
                        document.getElementById('txtDescripcionMes').value = 'DICIEMBRE';
                        return;
                    default:
                        document.getElementById('txtIdMes').value = '';
                        document.getElementById('txtDescripcionMes').value = '';
                        return;
                }
            }
        }

        function cmdEliminarArticulo_onclick(strArticuloId, strCaducidadMesId) {

            var confirmacion = confirm('Desea eliminar este articulo?');
            if (confirmacion == true) {

                document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdEliminar&strArticuloPorEliminar=' + strArticuloId + '&strCaducidadMesId=' + strCaducidadMesId;
                document.forms[0].target = "ifrOculto";
                document.forms[0].submit();
            }
        }
        //-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form id="frmMercanciaCapturarCaducidadArticulos" name="frmMercanciaCapturarCaducidadArticulos" onSubmit="return frmMercanciaCapturarCaducidadArticulos_onsubmit()" action="about:blank" method="post">
    <table width="780" border="0" cellpadding="0" cellspacing="0">
        <tr> 
            <td valign="top" height="98" width="100%"><script language="JavaScript">crearTablaHeader()</script></td>
        </tr>
        <tr>
            <td valign="top" height="34" width="100%"><img src="../static/images/pixel.gif" width="1" height="34"></td>
        </tr>
        <tr> 
            <td width="100%"> 
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr> 
                        <td width="10" bgcolor="#ffffff"><img src="../static/images/pixel.gif" width="10" height="8"></td>
                        <td width="583" class="tdmigaja">
                            <span class="txdmigaja">Está en : 
                            </span>
                            <a href="Mercancia.aspx" class="txdmigaja">Mercancía</a>
                            <span class="txdmigaja"> 
                                : Capturar Caducidad Articulos
                            </span>
                        </td>
                        <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
                    </tr>
                    <tr> 
                        <td width="10">&nbsp;</td>
                        <td width="583" valign="top" class="tdtablacont">
                            <script language="JavaScript">crearDatosSucursal()</script>
                            <br /><span class="txtitulo">
                                <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle">
                                Caducidad Articulos - Captura
                            </span>
                            <span class="txcontenido">
                                En esta pantalla se agrega la caducidad de los articulos asi como la cantidad existente del mismo.
                            </span>
                            <br />
                            <table id="tblDetalle" width="100%" class="tdenvolventetablas" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="tdtittablas3" align="left" width="120">Código</td>
                                    <td class="tdtittablas3" align="left" width="60">Existencia</td>
                                    <td class="tdtittablas3" align="left" width="240">Descripción</td>
                                    <td vAlign="middle" width="50" rowspan="2" align="center"> 
                                       
                                    </td>
                                </tr>
                                <tr> 
                                    <td class="txtitintabla" vAlign="middle" width="120" height="20"> 
                                      <input class="campotablahabilitadoderecha" type="text" id="txtArticuloId" name="txtArticuloId"  autocomplete="off" maxLength="16" size="16" onKeyPress="return txtArticuloId_onKeyPress(event);">
                                      <a id="objLupaArticulo" onclick="return objLupaArticulo_onclick()"> 
                                      <img height="17" src="../static/images/icono_lupa.gif" width="16" align="absMiddle" border="0"></a> 
                                    </td>
                                    <td class="tdpadleft5" vAlign="middle" width="60"> 
                                        <input class="campotablahabilitadoderecha" type="text" id="txtExistencia" name="txtExistencia" autocomplete="off" maxLength="3" size="10" onKeyPress="return txtExistencia_onKeyPress(event);">
                                    </td>
                                    <td class="txtitintabla" vAlign="middle" width="240" colspan="3"> 
                                      <input class="campotablaresultadoenvolventeazul" type="text" name="txtDescripcionArticulo" readOnly size="40"> 
                                    </td>
                                  </tr>
                                  <tr>
                                      <td class="tdtittablas3" align="left" width="120">Mes de Caducidad</td>
                                  </tr>
                                  <tr>
                                      <td class="txtitintabla" vAlign="middle" width="120" height="20">
                                          <input type="text" id="txtIdMes" name="txtIdMes" maxlength="2" size="10" onKeyPress="return txtMesId_onKeyPress(event);" onblur="txtIdMes_onblur();" class="campotablahabilitadoderecha"/>
                                      </td>
                                      <td colspan="2" ><input id="txtDescripcionMes" class="campotablaresultadoenvolventeazul" type="text" name="txtDescripcionMes" readOnly size="30" > </td>
                                      <td vAlign="middle" width="50" align="rigth">
                                          <input language="javascript" class="campotabla" type="hidden" id="txtFolioId" name="txtFolioId" width="5"> 
                                      <input class="boton" type="button" id="cmdAgregar" value="Agregar" name="cmdAgregar" onclick="return cmdAgregar_onclick()"> 
                                    </td>
                                  </tr>
                                </table> 
                            <br> 
                            <div id="tblResultados" width="100%"></div>
                          <br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()">
                               <input name="cmdImprimir" type="button" class="boton" value="Limpiar campos" onClick="return cmdLimpiarCampos_onclick()"> 
                               <input name="cmdGuardar" type="button" class="boton" value="Guardar" onClick="return cmdGuardar_onclick()">
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
            <div id="divListaArticulos">
                <%= Me.strTablaArticulosPorAgregar()%>-->
            </div>
        <div id="divConsultaDetalle">
                <!--<= Me.strTablaConsultaDetalle()%>-->
            </div>            
        </div>
    <iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrPaginaenBlanco.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</html>

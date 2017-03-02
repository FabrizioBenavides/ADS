
<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RentaEspaciosAsignar.aspx.vb" Inherits="com.isocraft.backbone.ccentral.RentaEspaciosAsignar" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<HTML>
<HEAD>
<title>Benavides: Exhibiciones adicionales</title>

<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">

<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">

<script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/tools.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/cal_format00.js"></script>

<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script id="clientEventHandlersJS" language="javascript" type="text/javascript">

<!--
    strUsuarioNombre = "<%= strUsuarioNombre %>";
    strFechaHora = "<%= strHTMLFechaHora %>";


    function window_onload() {
        document.forms[0].action = "<%= strFormAction %>";

        <%= LlenarControlDivision()%>
        <%= LlenarControlZona()%>

        var intDireccionId = "<%= intDireccionId %>";
        var intZonaId = "<%= intZonaId %>";

        if (intDireccionId == "-1") {
            document.forms[0].elements["cboDireccionOperativa"].options[1].selected = true;
            document.forms[0].elements["cboZonaOperativa"].disabled = true;
            disabledZona();
        }
        if (intZonaId == "-1") {
            document.forms[0].elements["cboZonaOperativa"].options[1].selected = true;
        }
        

        //Id de la Exhibicion
        document.getElementById('hdnExhibicionId').value = '<%= strExhibicionId()%>';

        //Variable que indica la forma en que se cargaron las sucursales. Por archivo o por seleccion de combos.
        document.getElementById('hdnCargadoDeSucursales').value = '<%= strCargadoDeSucursales()%>'; 

        //Filtros para cargar las sucursales
        var intOpcionCarga = "<%= intOpcionCarga()%>";
        if (intOpcionCarga == 1) {

            //Por Seleccion
            document.forms[0].elements['cmdFiltroAsignacion1'].checked = true;
            inhabilitarCargaArchivo();
        }
        else {

            //Por Carga de archivo
            document.forms[0].elements['cmdFiltroAsignacion2'].checked = true;
            inhabilitarSeleccionSucursal();
        }

        document.onhelp = FALSE_FUNCTION;
        window.onhelp = FALSE_FUNCTION;

        // Disable the F1, F3 and F5 keys. Without this, browsers that have these
        // function keys assigned to a specific behaviour (i.e., opening a search
        // tab, or refreshing the page) will continue to execute that behaviour.
        //
        document.onkeydown = function disableKeys() {
            // Disable F1, F3 and F5 (112, 114 and 116, respectively).
            //
            if (typeof event != 'undefined') {
                if ((event.keyCode == 112) ||
                    (event.keyCode == 114) ||
                    (event.keyCode == 116)) {
                    event.keyCode = 0;
                    return false;
                }
            }
        };
    }
    var FALSE_FUNCTION = new Function("return false");

    function disabledZona() {
        document.getElementById("cboZonaOperativa").disabled = true;
    }

    function cmdAsignar_onclick() {

        if (document.getElementById('tblSucursales').innerHTML == '') {
            return (false);
        }

        if (trim(document.getElementById('hdnTotalDePartidas').value) == '') {
            return (false);
        }
        else {

            var confirmar = confirm('Desea asignar las sucursales seleccionadas?');
            if (confirmar == true) {

                document.getElementById('tblResultados').innerHTML = parent.document.getElementById('tblResultados').innerHTML;

                document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdAsignar';
                document.forms[0].submit();

                return (true);
            }
        }
    }

    function cmdSeleccionar_onclick() {
        var cont = 1;		//Contador
        var idChkBox = ""	//idCheckBox
        var trChkBox = ""	//Checkbox (renglon)		
        var numChkBox = 0	//Total de checkbox's seleccionados

        //Tabla y encabezados.
        var tabla = "<table id='tblDatosArticulo' width='100%' border='0' cellpadding='0' cellspacing='0'>";
        var tabla = "<table id='tblDatosArticulo' width='100%' border='0' cellpadding='0' cellspacing='0'>";
        tabla = tabla + "<tr class='trtitulos'>";
        tabla = tabla + "<th class='rayita' align='left' valign='top'>P. Regular</th>";
        tabla = tabla + "<th class='rayita' align='left' valign='top'>P. Oferta</th>";
        tabla = tabla + "<th class='rayita' align='left' valign='top'>Tu Ahorro</th>";
        tabla = tabla + "<th class='rayita' align='left' valign='top'>Vigencia</th>";
        tabla = tabla + "<th class='rayita' align='left' valign='top'>Descripción</th>";
        tabla = tabla + "</tr>";

        for (var x = 0; x < cont; x++) {
            //Se forma el id a buscar.
            idChkBox = "chkCodigo" + cont;					//Se forma el identificador de los checkbox's
            trChkBox = document.getElementById(idChkBox);	//Elementos

            if (Boolean(trChkBox)) {

                //Si se ha seleccioando la casilla principal se seleccioann todos.
                if (trChkBox.checked) {
                    var strColorRegistro = "";
                    numChkBox = numChkBox + 1;

                    //Clase para los TD's
                    if ((numChkBox % 2) != 0) {
                        strColorRegistro = "'tdceleste'";
                    }
                    else {
                        strColorRegistro = "'tdblanco'";
                    }

                    //Se forma la tabla con productos seleccionados.
                    tabla = tabla + "<tr id=trSeleccionado" + numChkBox + ">";
                    tabla = tabla + "<td class=" + strColorRegistro + " vAlign='middle'>" + document.getElementById('tdPrecioNormal' + cont).innerHTML + "</td>";
                    tabla = tabla + "<td class=" + strColorRegistro + " vAlign='middle'>" + document.getElementById('tdPrecioOferta' + cont).innerHTML + "</td>";
                    tabla = tabla + "<td class=" + strColorRegistro + " vAlign='middle'>" + document.getElementById('tdTuAhorro' + cont).innerHTML + "</td>";
                    tabla = tabla + "<td class=" + strColorRegistro + " vAlign='middle'>" + document.getElementById('tdVigencia' + cont).innerHTML + "</td>";
                    tabla = tabla + "<td class=" + strColorRegistro + " vAlign='middle'>" + document.getElementById('tdDescripcion' + cont).innerHTML + "</td>";
                    tabla = tabla + "</tr>";
                }

                cont = cont + 1;
            }
        }
        document.getElementById('hdnTotalDePartidas').value = cont - 1;

        tabla = tabla + "</table>";

        if (numChkBox > 0) {
            //Se muestra la tabla con los productos seleccionados.
            document.getElementById("divTblProductosSeleccionados").innerHTML = tabla;
        }
        else {
            document.getElementById("divTblProductosSeleccionados").innerHTML = "";
            alert('No hay productos seleccionados');
        }
    }

    function cmdEliminar_onclick(strCentroLogisticoId) {

        var confirmar = confirm('Desea eliminar la asignacion de esta sucursal?');
        
        if(confirmar == true){

            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdEliminar&strCentroLogisticoId=' + strCentroLogisticoId;
            document.forms[0].submit();

            return (true);
        }
    }

    function cmdCancelar_onclick() {
        window.location.href = "SucursalSenalizacion.aspx";
    }

    function cmdSalir_onclick() {
        window.location.href = "RentaEspaciosConsulta.aspx";
    }

    function cmdImportar_onclick() {

        document.forms[0].elements["cmdFiltroAsignacion2"].checked = true
        
        inhabilitarSeleccionSucursal();
        
        var _archivo = trim(document.getElementById('txtArchivo').value);

        if (_archivo == '') {

            alert('Capture la ruta del archivo');
            return (false);
        }
        else {

            var extension = _archivo.substring(_archivo.length - 3)

            if (extension.toUpperCase() != 'CSV') {

                alert('El formato del archivo debe de ser .CSV');
                return (false);
            }

            //El campo "hdnCargadoDeSucursales" indicara como se cargo la tabla de las sucursales, en este caso sera cmdImportar.
            document.getElementById('hdnCargadoDeSucursales').value = 'cmdImportar';

            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdImportar'
            document.forms[0].target = '_self';
            document.forms[0].submit();
        }
    }

    function trim(stringToTrim) {
        return stringToTrim.replace(/^\s+|\s+$/g, "");
    }

    
    function doSubmitSucursales(c, t, p) {
        
        //if (p == document.getElementById('txtCurrentPageSucursales').value) {
            return;
        //}
        
        if (p == null) {
            p = document.getElementById('txtCurrentPageSucursales').value;
        }
        else {
            document.getElementById('txtCurrentPageSucursales').value = p;
        }
     
     
        //Por Seleccion la "Carga de las Sucursales"
        var strComando = 'cmdConsultarSucursales';
        
        //Por Carga de archivo la "Carga de las Sucursales"
        if (document.getElementById('hdnCargadoDeSucursales').value == 'cmdImportar') {
            
            strComando = 'cmdImportar';
        }

        document.forms[0].action = '<%= strThisPageName%>?strCmd=' + strComando + '&pager=true&p=' + p;
        
        document.forms[0].target = "ifrOculto";
        document.forms[0].submit();
    }

    function doSubmit(c, t, p) {

        return;

        if (p == null) {
            p = document.getElementById('txtCurrentPage').value;
        }
        else {
            document.getElementById('txtCurrentPage').value = p;
        }
        document.forms[0].action =
            '<%= strThisPageName%>?strCmd=cmdConsultar&pager=true&p=' + p;
    document.forms[0].target = "ifrOculto";
    document.forms[0].submit();
}

    function cboDireccionOperativa_onchange() {

        if (document.getElementById("cboDireccionOperativa").selectedIndex != 0) {

            var strCmd = '';
            if (document.getElementById("cboDireccionOperativa").selectedIndex == 1) {

                document.getElementById("cboZonaOperativa").value = "-1";
                document.getElementById("cboZonaOperativa").disabled = true;
                strCmd = 'cmdConsultarSucursales';
            }
            else {
                document.getElementById("cboZonaOperativa").value = "0";
            }

            //El campo hdnCargadoDeSucursales indicara como se cargo la tabla de las sucursales, en este caso sera cmdConsultarSucursales.
            document.getElementById('hdnCargadoDeSucursales').value = 'cmdConsultarSucursales';

            document.forms[0].action = '<%= strThisPageName%>?strCmd=' + strCmd;
            document.forms[0].target = '_self';
            document.forms[0].submit();
            return (true);
    }

    return (false);
    }

function cboZonaOperativa_onchange() {
    
    if ((document.getElementById("cboDireccionOperativa").selectedIndex > 0) && (document.getElementById("cboZonaOperativa").selectedIndex != 0)) {

        //El campo hdnCargadoDeSucursales indicara como se cargo la tabla de las sucursales, en este caso sera cmdConsultarSucursales.
        document.getElementById('hdnCargadoDeSucursales').value = 'cmdConsultarSucursales';

        document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultarSucursales'
        document.forms[0].target = '_self';
        document.forms[0].submit();
    }

    return (false)
}

//Radios buttons
function cmdFiltroAsignacion_onfocus(id) {
    
    if (document.forms[0].elements["cmdFiltroAsignacion1"].checked == true) {
        //Seleccion de sucursal
        inhabilitarSeleccionSucursal();
    }
    else {
        //Por carga de archivo
        inhabilitarCargaArchivo();
    }
}

function inhabilitarSeleccionSucursal() {
    document.getElementById('cboDireccionOperativa').disabled = true;
    document.getElementById('cboZonaOperativa').disabled = true;
    document.getElementById('txtArchivo').disabled = false;
    document.getElementById('cmdImportarArchivo').disabled = false;
}

function inhabilitarCargaArchivo() {
    document.getElementById('cboDireccionOperativa').disabled = false;
    document.getElementById('cboZonaOperativa').disabled = false;
    document.getElementById('txtArchivo').disabled = true;
    document.getElementById('cmdImportarArchivo').disabled = true;
}

//CheckBox Sucursales
function fnMarcarTodos() {
    var cont = 1;
    for (var x = 0; x < cont; x++) {
        //Se forma el id a buscar.
        //idChkBox = "chkCodigo" + cont;					//Se forma el identificador de los checkbox's
        idChkBox = "chkCodigo" + x;					//Se forma el identificador de los checkbox's
        trChkBox = document.getElementById(idChkBox);

        //Si existe check box se selecciona o se quita la seleccion de "todos"	
        if (Boolean(trChkBox)) {
            if (document.getElementById('chkCodigo').checked == true)
            { trChkBox.checked = true }
            else
            { trChkBox.checked = false }

            cont = cont + 1;
        }
    }
}

function fnMarcarUno() {
    //Si se quita la seleccion a una sucursal y el check box todos esta seleccionado tambien se le quita la seleccion.
    if (document.getElementById('chkCodigo').checked == true) {

        document.getElementById('chkCodigo').checked = false;
    }
}

    //-->
		</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onload="return window_onload()">
<form id="frmAsignarRentaEspacios" method="post" name="frmAsignarRentaEspacios" action="about:blank" onSubmit="return frmAsignarRentaEspacios_onsubmit()" runat="server">
  <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
    <tr> 
      <td> <script language="JavaScript" type="text/javascript">crearTablaHeader()</script> </td>
    </tr>
  </table>
  <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
    <tr> 
      <td width="10">&nbsp;</td>
      <td class="tdtab" width="770">Está en : <A href="../_Manager/InicioHome.aspx">Central</A> 
        : Exhibiciones Adicionales </td>
    </tr>
  </table>
    <br />
     <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
      <tr>
         <td>
            <h1>Exhibiciones Adicionales - Asignación de Sucursales</h1>
         </td>
      </tr>
    </table>
    <div id="tblResultados" style="width:780px"></div>
    <br />
  <table border="1" cellSpacing="0" cellPadding="0" style="width:780px;">
      <tr>
          <td class="tdtexttablebold"> 
              <input id="cmdFiltroAsignacion1" value="1" type="radio" name="cmdFiltroAsignacion" checked onfocus="return cmdFiltroAsignacion_onfocus(this.value)">Seleccion de sucursales
          </td>
          <td class="tdtexttablebold">
              <input id="cmdFiltroAsignacion2" value="2" type="radio" name="cmdFiltroAsignacion" onfocus="return cmdFiltroAsignacion_onfocus(this.value)">Importar sucursales desde archivo
          </td>
      </tr>
      <tr>
          <td>
              <table border="0" cellSpacing="0" cellPadding="0" width="390">
                  <tr id="trDivision"> 
                        <td class="tdtexttablebold" width="119">Dirección:</td>
                        <td class="tdpadleft5" width="440"> 
                            <select id="cboDireccionOperativa" class="campotabla" onchange="return cboDireccionOperativa_onchange()" name="cboDireccionOperativa" style="width:150px">
                                <option selected value="0">&raquo; Elija una dirección &laquo;</option>
                                <option value="-1">&raquo; Todas las direcciones &laquo;</option>
                          </select> 
                        </td>
                      </tr>
                      <tr id="tr2"> 
                        <td class="tdtexttablebold" width="119">Zona:</td>
                        <td class="tdpadleft5" width="440"> 
                            <select id="cboZonaOperativa" class="campotabla" onchange="return cboZonaOperativa_onchange()" name="cboZonaOperativa" style="width:150px">
                                <option selected value="0">&raquo; Elija una zona &laquo;</option>
                                <option value="-1">&raquo; Todas las zonas &laquo;</option>
                            </select> 
                        </td>
                      </tr>
                     </table>
                  </td>
                  <td class="tdtexttablebold">
                      <table border="0" cellSpacing="0" cellPadding="0" width="390">
                          <tr>
                              <td class="tdtexttablebold"> 
                                  
                              </td>
                          </tr>
                          <tr width="100%"> 
                                <td class="tdtexttablebold" width="12%">Archivo</td>
                                <td class="tdpadleft5"><input id="txtArchivo" class="field" maxLength="55" size="55" type="file" name="txtArchivo"
										                    runat="server" > </td>
                          </tr>
                          <tr> 
                            <td align="right"></td>
                            <td class="tdpadleft5" height="10" colSpan="2" align="right"> 
                                <input id="cmdImportarArchivo" class="button" value="Cargar Archivo" type="button" name="cmdImportarArchivo" onclick="return cmdImportar_onclick();" style="margin-top:20px;">
                            </td>
                        </tr>
                      </table>
                  </td>
              </tr>
        </table>
    <br />
    <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
        <tr>
            <td style="vertical-align:top">
                <table border="0" cellSpacing="0" cellPadding="0" width="350">
                    <tr>
                        <td valign="top"><div id="tblSucursales" style="width:100%"></div></td>
                    </tr>
                 </table>
            </td>
            <td>
                <table border="0" cellSpacing="0" cellPadding="0" width="80">
                      <tr>
                          <td class="tdpadleft5" height="10" colSpan="2" align="center"> 
                            </td>
                      </tr>    
                      </table>
                  </td>
                  <td style="vertical-align:top">
                      <table border="0" cellSpacing="0" cellPadding="0" width="350">
                          <tr>
                              <td valign="top">
                                  <div id="tblSucursalesAsignadas" style="width: 100%;"></div>
                              </td>
                          </tr>
                      </table>
                  </td>
              </tr>
        </table>
    <table border="0" cellSpacing="0" cellPadding="0" width="780">
        <tr>
            <td class="tdpadleft5" height="10" colSpan="2" align="right"> 
                <input id="btnregresar" class="button" value="Regresar" type="button" name="cmdAceptar" onclick="return cmdSalir_onclick();" style="margin-top:20px;">
                <input type="hidden" id="hdnTotalDePartidas" name="hdnTotalDePartidas" >
                <input type="hidden" id="hdnExhibicionId" name="hdnExhibicionId">
                <input type="hidden" id="hdnCargadoDeSucursales" name="hdnCargadoDeSucursales">
                <input type="hidden" id="hdnArchivo" name="hdnArchivo">
            </td>
        </tr>    
    </table>
    <br />
  <table border="0" cellSpacing="0" cellPadding="0" width="780">
    <tr> 
      <td> 
          <script language="JavaScript" type="text/javascript">crearTablaFooterCentral()</script> 
      </td>
    </tr>
  </table>
    <script language="JavaScript">
	<!--
    new menu(MENU_ITEMS, MENU_POS);
    //-->
  </script>
</form>
<div style="display:none;"> 
  <div id="divConsultaExhibicion"> 
      <%= Me.strTablaConsultaExhibicion()%> 
  </div>
    <div id="divConsultaSucursales">
        <%= Me.strTablaConsultaSucursales()%>
    </div>
    <div id="divConsultaSucursalesAsignadas">
        <%= Me.strTablaConsultaSucursalesAsignadas()%>
    </div>
</div>
    <script language="JavaScript" type="text/javascript">

        //Variable que indica la ruta del archivo con el que se cargaron las sucursales.
        document.getElementById('hdnArchivo').value = '<%= strArchivo()%>'; 

        var strTotalDePartidas = "<%= strTotalDePartidas()%>"
        parent.document.getElementById('hdnTotalDePartidas').value = strTotalDePartidas;

        
    </script>
<iframe id="ifrOculto" name="ifrOculto" src="" width="0" height="0"></iframe>
<iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</HTML>



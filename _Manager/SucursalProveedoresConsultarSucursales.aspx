<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalProveedoresConsultarSucursales.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalProveedoresConsultarSucursales" %>
<HTML>
<HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<LINK href="css/menu.css" type="text/css" rel="stylesheet">
<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/calendario.js"></script>
<script language="JavaScript" src="js/cal_format00.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function Pop(url, width, height) {
   var Win = window.open(url,'Pop','width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
       
   return(false);
}


function window_onload() {
   document.forms[0].action = "<%= strFormAction %>";   
   
   var intEstadoId = "<%= intEstadoId %>";
   var intCiudadId = "<%= intCiudadId %>";
   var intCadenaId = "<%= intCadenaId %>";
   var strSucursalId = "<%= strSucursalId %>";
   
   var intCompaniaid ="<%=intCompaniaid%>";
   var intSucursalid ="<%=intSucursalid%>";
   
   if (intEstadoId == "-1") {
       document.forms[0].elements["cboEstado"].options[1].selected = true;
       document.forms[0].elements["cboCiudad"].disabled = true;
       document.forms[0].elements["cboSucursal"].disabled = true;
   }
     
   if (intCiudadId == "-1") {
       document.forms[0].elements["cboCiudad"].options[1].selected = true;
       document.forms[0].elements["cboSucursal"].disabled = true;
   }
   
   document.forms[0].elements["cboCadena"].options[intCadenaId].selected = true;
   
   if (strSucursalId == "-1") {
       document.forms[0].elements["cboSucursal"].options[1].selected = true;
   }
   
   document.forms[0].elements["optProveedor"].value = "<%=strOpcProveedor %>";
        
   <%= strLlenarEstadoComboBox() %>
   <%= strLlenarCiudadComboBox() %>
   <%= strLlenarSucursalComboBox() %>
   <%= strJavascriptWindowOnLoadCommands %>
      
}

function cboEstado_onchange() {
   if (document.forms[0].elements["cboEstado"].selectedIndex > 0) {   
       document.forms[0].elements["cboCiudad"].selectedIndex = 0;  
            
       document.forms[0].action = "<%= strFormAction %>";
       document.forms[0].submit();
   }
   return(true);
}

function cboCiudad_onchange() {
   if (document.forms[0].elements["cboEstado"].selectedIndex > 0 && document.forms[0].elements["cboCiudad"].selectedIndex > 0) {
       document.forms[0].elements["cboSucursal"].selectedIndex = 0;
       
       document.forms[0].action = "<%= strFormAction %>";
       document.forms[0].submit();
   }
   return(true);
}

function cboCadena_onchange() {
   var blnActualizarSuc = true;

   if ( document.forms[0].elements["cboEstado"].selectedIndex == 0 && document.forms[0].elements["cboCiudad"].selectedIndex == 0 && document.forms[0].elements["cboSucursal"].selectedIndex == 0 ) {
       blnActualizarSuc = false;      
   }
   
   if ( blnActualizarSuc && document.forms[0].elements["cboEstado"].selectedIndex > 1 &&  document.forms[0].elements["cboCiudad"].selectedIndex == 0 ) {
       blnActualizarSuc = false;
   }  

    if (blnActualizarSuc) {
       document.forms[0].elements["cboSucursal"].selectedIndex = 0;       
       document.forms[0].action = "<%= strFormAction %>";
       document.forms[0].submit();
    }
	
   return(true);
}
function cboSucursal_onchange() {
   if (blnValidarSubmit()) {
       document.forms[0].action = "<%= strFormAction %>";
       document.forms[0].submit(); 
    }
}


function blnValidarSubmit() {
   var blnValidar = true;
   
   if ( document.forms[0].elements["cboEstado"].selectedIndex == 0 && document.forms[0].elements["cboCiudad"].selectedIndex == 0 && document.forms[0].elements["cboSucursal"].selectedIndex == 0 ) {
       blnValidar = false;
       alert("Seleccionar al menos algun criterio de Estado, Ciudad o Sucursal");
   }
   
   if ( blnValidar && document.forms[0].elements["cboEstado"].selectedIndex > 1 &&  document.forms[0].elements["cboCiudad"].selectedIndex == 0 ) {
       blnValidar = false;
       alert("Seleccionar el criterio de Ciudad");
   }
   
   if ( blnValidar && document.forms[0].elements["cboCiudad"].selectedIndex > 1 &&  document.forms[0].elements["cboSucursal"].selectedIndex == 0 ) {
       blnValidar = false;
       alert("Seleccionar el criterio de Sucursal");
   }      
   
   return blnValidar;
   
}

function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];
    
    if (action=="AgregarProveedor") {
    
       
       url = 'SucursalProveedoresAsignar.aspx?intEstadoId=' + '<%= intEstadoId %>' + '&intCiudadId=' + '<%= intCiudadId %>' + '&intCadenaId=' + '<%= intCadenaId %>' + '&strSucursalId=' + '<%= strSucursalId %>';
       
       var Win = window.open(url,'Pop','width=640,height=580,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );
       
       return;
    }
         
	
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{
		params+= "&" + args[i] + "=" + args[i+1]
	}
	
	document.forms[0].action = "SucursalProveedoresConsultarSucursales.aspx?strCmd=" + action + params;
	document.forms[0].submit(); 
	
}


function cmdRegresar_onclick() {
   window.location.href = "SucursalMercanciasProveedores.aspx";
}

function cmdConsultar_onclick() {
   if (blnValidarSubmit()) {          
       document.forms[0].action = "<%=strFormAction%>"; 
       document.forms[0].submit();         
   }    
}
function cmdLimpiar_onclick() {
    window.location.href = "SucursalProveedoresConsultarSucursales.aspx";
}


//-->
				</script>
</HEAD>
<body language="javascript" onload="return window_onload()">
<form name="frmPage" action="about:blank" method="post">
  <table cellSpacing="0" cellPadding="0" width="780" border="0">
    <tr> 
      <td> <script language="JavaScript">crearTablaHeader()</script> </td>
    </tr>
  </table>
  <table cellSpacing="0" cellPadding="0" width="780" border="0">
    <tr> 
      <td width="10">&nbsp;</td>
      <td class="tdtab" width="770">Está en : <a href="SucursalHome.aspx">Sucursal</a> 
        :<a href="SucursalMercancias.aspx">Mercancias</a>:<a href="SucursalMercanciasProveedores.aspx">Proveedores</a>:Relación 
        proveedor sucursal</td>
    </tr>
  </table>
  <table cellSpacing="0" cellPadding="0" width="780" border="0">
    <tr> 
      <td class="tdgeneralcontent"> <h1>Consultar relación Sucursal Proveedor</h1>
        <p>Aquí podrá consultar los provedores asignados a una sucursal.</p>
        <h2>Alcance de la Consulta</h2>
        <table cellSpacing="0" cellPadding="0" width="100%" border="0">
          <tr> 
            <td class="tdtexttablebold" width="90">* Estado:</td>
            <td class="tdpadleft5" width="190"> <select name="cboEstado" class="field" id="cboEstado" language="javascript" onChange="return cboEstado_onchange()">
                <option value="0" selected>--- Elija un estado ---</option>
                <option value="-1">Todos los estados</option>
                <option>--------------------</option>
              </select> </td>
            <td width="89">&nbsp;</td>
            <td width="375">&nbsp;</td>
          </tr>
          <tr> 
            <td class="tdtexttablebold">* Ciudad:</td>
            <td class="tdpadleft5"><select name="cboCiudad" class="field" id="cboCiudad" onchange="return cboCiudad_onchange()">
                <option value="0" selected>-- Elija una ciudad --</option>
                <option value="-1">Todas las ciudades</option>
                <option>--------------------</option>
              </select> </td>
            <td width="89">&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr> 
            <td class="tdtexttablebold">* Cadena:</td>
            <td class="tdpadleft5"><select name="cboCadena" class="field" id="cboCadena" onchange="return cboCadena_onchange()">
                <option value="0" selected>--- Todas ---</option>
                <option value="1">FARMACIAS BENAVIDES S.A.B. DE C.V.</option>
                <option value="2">FARMACIAS ABC DE MEXICO S.A. DE C.V.</option>
              </select> </td>
            <td width="89">&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr> 
            <td class="tdtexttablebold">* Sucursal:</td>
            <td class="tdpadleft5"> <select name="cboSucursal" class="field" id="cboSucursal" onchange="return cboSucursal_onchange()">
                <option value="0" selected>-- Elija una sucursal --</option>
                <option value="-1">Todas las sucursales</option>
                <option>--------------------</option>
              </select> </td>
            <td width="89">&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr> 
            <td class="tdtexttablebold">* Proveedor:</td>
            <td class="tdpadleft5"> <input class="field" id="optProveedor" type="text" autocomplete="off"  maxlength="12" size="24" name="optProveedor"  value='<%=Request("strOpcProveedor")%>'> 
            </td>
            <td width="89">&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
        </table>
        <br> <table cellSpacing="0" cellPadding="0" width="100%" border="0">
          <tr> 
            <td> <input language="javascript" class="button" id="cmdRegresar" onClick="return cmdRegresar_onclick()"
										type="button" value="Regresar" name="cmdRegresar"> 
              <input language="javascript" class="button" id="cmdConsultar" onclick="return cmdConsultar_onclick()"
										type="button" value="Consultar" name="cmdConsultar"> 
              <input language="javascript" class="button" id="cmdLimpiar" onclick="return cmdLimpiar_onclick()"
										type="button" value="Limpiar" name="cmdLimpiar"> 
            </td>
          </tr>
          <tr> 
            <td> <br> <%=strConsultarProveedores%> </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <table cellSpacing="0" cellPadding="0" width="780" border="0">
    <tr> 
      <td> <script language="JavaScript">crearTablaFooterCentral()</script> </td>
    </tr>
  </table>
  <script language="JavaScript">
    <!--
    new menu (MENU_ITEMS, MENU_POS);
    //-->
			</script>
</form>
</body>
</HTML>

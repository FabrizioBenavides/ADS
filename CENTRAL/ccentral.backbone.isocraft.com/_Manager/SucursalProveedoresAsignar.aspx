<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" enableViewState="False" Explicit="True" Trace="False" Strict="True" CodeBehind="SucursalProveedoresAsignar.aspx.vb"      Inherits="com.isocraft.backbone.ccentral.SucursalProveedoresAsignar" codePage="28592" %>
<HTML>
<HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<LINK href="css/menu.css" type="text/css" rel="stylesheet">
<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
<script language="JavaScript" src="../static/scripts/FuncionesString.js" type="text/JavaScript"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";
var popBuscap;

function window_onload() {
  document.forms[0].action = "<%= strFormAction %>";    
  <%= strJavascriptWindowOnLoadCommands %>
  document.forms(0).txtProveedorNombreId.focus()
    
}

// Mandar ventana de consulta
function Pop(url, width, height) {
    popBuscap = window.open(url,'popBuscaProveedor','dependent=yes,width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
	return(false);
}


function txtProveedorNombreId_onKeyDown() {
	if(event.keyCode==13) { 
     event.keyCode = 9;
	 event.returnValue = true;
	}	 
}

function txtProveedorNombreId_onblur() {

   strProveedorCapturado = Trim(document.forms[0].elements['txtProveedorNombreId'].value); 

   if (strProveedorCapturado.length > 0 && strProveedorCapturado!='0') {
      
      if (document.forms[0].elements['hdnProveedorNombreId'].value != document.forms[0].elements['txtProveedorNombreId'].value) {	       
           objLupaProveedor_onclick(); 
      }
   }
   else {
      return true;
   }
   
}

// Lupa para listar proveedores
function objLupaProveedor_onclick() {
   
   var valida = true;   
   var intCuentaApostrofes=0;  
   var strtxtProveedorNombreId = "";
   
   strtxtProveedorNombreId = Trim(document.forms[0].elements['txtProveedorNombreId'].value);
         
   if (strtxtProveedorNombreId.length< 1) {
       alert("Teclear Número de proveedor o descripción");
       document.forms[0].elements['txtProveedorNombreId'].focus();
       return(false);
   }
        
   intCuentaApostrofes = strtxtProveedorNombreId.search("'");
      
   if (intCuentaApostrofes != -1) {
       document.forms[0].elements['txtProveedorNombreId'].value = '';
       alert("No se deben de capturar apostrofes");
       document.forms[0].elements['txtProveedorNombreId'].focus();
       return(false);
   }
   
   if (document.forms[0].elements['hdnProveedorNombreId'].value == document.forms[0].elements['txtProveedorNombreId'].value) {	       
      return(true);   
   }
   
   var strtxtProveedorB = Trim((document.forms[0].elements['txtProveedorNombreId'].value).substring(0,4));

   if (isNaN(strtxtProveedorB) || strtxtProveedorB.length<1 ) // Esta capturando Descripcion
   {   
             	         
      strEvalJs='opener.txtProveedorNombreId_onblur();';
      strParametros = ''		
      strParametros = strParametros + ' campoProveedorId=hdnProveedorId';
      strParametros = strParametros + '&campoProveedorNombreId=txtProveedorNombreId';
      strParametros = strParametros + '&campoProveedorRazonSocial=txtProveedorRazonSocial';
      strParametros = strParametros + '&strProveedorId=' + document.forms[0].elements['txtProveedorNombreId'].value;
      	  			       
      Pop('PopProveedor.aspx?'+strParametros+'&strEvalJs='+strEvalJs,500,540); 
   }   
   else {
   
       document.forms[0].action = '<%=strFormAction%>?strCmd=BuscarProveedor&intEstadoId=' + '<%= intEstadoId %>' + '&intCiudadId=' + '<%= intCiudadId %>' + '&intCadenaId=' + '<%= intCadenaId %>' + '&strSucursalId=' + '<%= strSucursalId %>';
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target='';  
  }  
  
}	
  
function fnUpBuscarProveedor (intProveedorId,strProveedorNombreId,strProveedorRazonSocial,strProveedorRFC, intError) {  

    if(intError == 0){
        document.forms(0).hdnProveedorId.value = intProveedorId;
     	document.forms(0).hdnProveedorNombreId.value = strProveedorNombreId;
		document.forms(0).txtProveedorNombreId.value = strProveedorNombreId;
	    document.forms(0).txtProveedorRazonSocial.value = strProveedorRazonSocial;
	}
	else{
		alert("Proveedor no encontrado.");

		document.forms(0).hdnProveedorId.value = '';		
		
		document.forms(0).hdnProveedorNombreId.value = '';
		document.forms(0).txtProveedorNombreId.value = '';
		document.forms(0).txtProveedorRazonSocial.value='';
		
		document.forms(0).txtProveedorNombreId.focus();
		document.forms(0).txtProveedorNombreId.select();
	}
}	 



function blnEntradaValida() {    
       if (document.forms(0).hdnProveedorId.value <1) {
           alert("Debe haberse capturado un proveedor valido");
		   document.forms(0).txtProveedorNombreId.focus()
           return(false);
       }    
  
   return (true);      
}

function cmdAgregar_onclick() {
   
   if (blnEntradaValida()) {   

       document.forms[0].action = '<%=strFormAction%>?strCmd=AgregarProveedor&intEstadoId='+ '<%= intEstadoId %>' + '&intCiudadId=' + '<%= intCiudadId %>' + '&intCadenaId=' + '<%= intCadenaId %>' + '&strSucursalId=' + '<%= strSucursalId %>';
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target='';      
   }
  
}
function fnUpAgregarProveedor(intError,intContadorAlta) {
	if (intError==-100) {
       alert("No se pudo agregar el proveedor a las sucursales indicadas");
	}
	else {
	   if (intContadorAlta>0) {
	  		alert("Se agregaron/actualizaron [" + intContadorAlta + "] registros");   
       }
	   else {
	   		alert("No se agrego ningun registro");   
	   }
	}
	      
   document.forms(0).hdnProveedorId.value = '';		
   document.forms(0).hdnProveedorNombreId.value = '';
   document.forms(0).txtProveedorNombreId.value = '';
   document.forms(0).txtProveedorRazonSocial.value='';  
   document.forms(0).txtProveedorNombreId.focus()        
       	
}


function cmdCerrar_onclick() {
   window.close();   
}

function window_onunload() {  
  if (!(popBuscap ==null)){
   popBuscap.close();
}
}

//-->
		</script>
</HEAD>
<body language="javascript" onload="return window_onload()" onunload="return window_onunload()">
<form id="frmMain" name="frmMain" method="post" encType="multipart/form-data">
  <table width="600" border="0" cellSpacing="0" cellPadding="0">
    <tr> 
      <td class="tdgeneralcontentpop" width="100%"> <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr> 
            <td><script language="JavaScript">crearTablaHeaderPop2()</script> 
            </td>
          </tr>
        </table>
        <h1>Agregar proveedor a Sucursal(es) seleccionada(s).</h1>
        <p>Se puede agregar el proveedor a una sucursal, a una ciudad o estado 
          completo segun el filtro que este seleccionado.</p>
        <table width="100%" border="0" cellSpacing="0" cellPadding="0">
          <tr> 
            <td class="tdtexttablebold" width="100%"> <input language='javascript' class='campotabla' id='txtProveedorNombreId' name='txtProveedorNombreId' onkeydown='txtProveedorNombreId_onKeyDown()' onblur='return txtProveedorNombreId_onblur()' type='text' maxLength='16' size='16' value='<%=Request.Form("txtProveedorNombreId")%>' autocomplete='off'> 
              &nbsp; <a id="objLupaProveedor" onclick="objLupaProveedor_onclick()"><IMG height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0"></a>&nbsp; 
              <span class="txconttablasrojo">
              <input class='campotablaresultado' id='txtProveedorRazonSocial' name='txtProveedorRazonSocial' readOnly maxLength='46' size='46' value='<%=Request.Form("txtProveedorRazonSocial")%>' border='0' >
              </span> </td>
          </tr>
          <tr> 
            <td colSpan="2" height="10" width="100%"><IMG height="10" src="images/pixel.gif" width="1"></td>
          </tr>
          <tr> 
            <td width="100%"> <input language="javascript" class="boton" id="cmdCerrar" onclick="return cmdCerrar_onclick()"
										type="button" value="Cerrar" name="cmdCerrar"> 
              &nbsp; <input language="javascript" class="boton" id="cmdAgregar" onclick="return cmdAgregar_onclick()"
										type="button" value="Agregar" name="cmdAgregar"> 
              <br> </td>
          </tr>
        </table>
        <table width="100%" border="0" cellSpacing="0" cellPadding="0">
          <tr> 
            <td width="100%"> <script language="JavaScript">crearTablaFooterPop2()</script> 
            </td>
          </tr>
          <tr> 
            <input type='hidden' value='<%=Request.Form("hdnProveedorId")%>' name='hdnProveedorId'>
            <input type='hidden' value='<%=Request.Form("hdnProveedorNombreId")%>' name='hdnProveedorNombreId'>
          </tr>
        </table></td>
    </tr>
  </table>
</form>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
</body>
</HTML>

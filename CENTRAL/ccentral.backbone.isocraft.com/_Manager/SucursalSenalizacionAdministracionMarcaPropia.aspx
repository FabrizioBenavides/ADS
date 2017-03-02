<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalSenalizacionAdministracionMarcaPropia.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalSenalizacionAdministracionMarcaPropia"%>

<HTML>
  <HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" src="../static/scripts/FuncionesString.js" type="text/JavaScript"></script>
<script id=clientEventHandlersJS language=javascript>

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
	document.forms[0].action = "<%=strFormAction%>";
    
    if("<%=strCmd%>" == "Editar")
	{
   		document.forms[0].elements["txtMarcaPropia"].value = "<%= strArticuloMarcaPropiaId %>";
   		document.forms[0].elements["txtArticuloDescripcion"].value = "<%= strArticuloMarcaPropiaDescripcion %>";
		document.forms[0].elements["txtMarcaLider"].value = "<%= strArticuloMarcaLiderId %>";
		document.forms[0].elements["txtArticuloLider"].value = "<%= strArticuloMarcaLiderDescripcion %>";
   }

	return(true); 
}

function cmdImprimir_onclick() {
	window.print();
}

function cmdCancelar_onclick() {
	window.location.href = "SucursalSenalizacion.aspx";
}


function isEnterKey(evt) {
  if (!evt) { 
    evt = window.event
  } else if (!evt.keyCode) {
    evt.keyCode = evt.which
  }
  return (evt.keyCode == 13)
}

function Pop(url, width, height) {
    var Win = window.open(url,'PopArticulos','width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
	return(false);
}

function txtMarcaPropia_onblur() {
   
   strArticuloCapturado = Trim(document.forms[0].elements['txtMarcaPropia'].value); 

   if (strArticuloCapturado.length > 0 && strArticuloCapturado != '0') {
      
      if (document.forms[0].elements['hdnMarcaPropia'].value != document.forms[0].elements['txtMarcaPropia'].value) {      
           objLupaArticulo_onclick(); 
      }
   }
   else {      
      return true;
   }
}

function txtMarcaLider_onblur() {
   
   strArticuloCapturado = Trim(document.forms[0].elements['txtMarcaLider'].value); 

   if (strArticuloCapturado.length > 0 && strArticuloCapturado != '0') {
      
      if (document.forms[0].elements['hdnMarcaLider'].value != document.forms[0].elements['txtMarcaLider'].value) {      
           objLupaArticuloLider_onclick(); 
      }
   }
   else {      
      return true;
   }
}

function txtMarcaPropia_onkeydown(objEvent) {
  if (isEnterKey(objEvent)) {
    txtMarcaPropia_onblur();
    return(false);
  }
}

function txtMarcaLider_onkeydown(objEvent) {
  if (isEnterKey(objEvent)) {
    txtMarcaLider_onblur();
    return(false);
  }
}

// Lupa para Buscar articulos
function objLupaArticulo_onclick() {
   
   var valida = true;   
   var intCuentaApostrofes=0;  
   var strtxtArticuloId = "";
   
   strtxtArticuloId = Trim(document.forms[0].elements['txtMarcaPropia'].value);
       
   if (strtxtArticuloId.length< 1) {
       alert("Teclear Número de articulo o descripción");
       document.forms[0].elements['txtMarcaPropia'].focus();
       return(false);
   }
        
   intCuentaApostrofes = strtxtArticuloId.search("'");
      
   if (intCuentaApostrofes != -1) {
       document.forms[0].elements['txtMarcaPropia'].value = '';              
       alert("No se deben de capturar apostrofes");       
       document.forms[0].elements['txtMarcaPropia'].focus();
       return(false);
   }
   
   if (document.forms[0].elements['hdnMarcaPropia'].value == document.forms[0].elements['txtMarcaPropia'].value) {	       
      return(true);   
   }
      
   if (isNaN(strtxtArticuloId)) // Esta capturando Descripcion
   {        
      strParametros = ''		      
      strParametros = strParametros + '&strArticuloIdNombre=' + document.forms[0].elements['txtMarcaPropia'].value;
      strParametros = strParametros + '&strArticulo=txtMarcaPropia';
      strParametros = strParametros + '&strArticuloNombreId=txtArticuloDescripcion';
      strEvalJs='opener.fnLupaArticulo();' ;
            	  			       
      Pop('../_ScriptLibrary/PopArticulo.aspx?blnSucursal=false'+strParametros+'&strEvalJs='+strEvalJs,500,540);       
   }   
   else {
       document.forms[0].elements['hdnMPoML'].value = '0'
       document.forms[0].action = '<%=strFormAction%>?strCmd=BuscarArticulo';
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target='';   
  }  
  
}

// Lupa para Buscar articulos
function objLupaArticuloLider_onclick() {
   
   var valida = true;   
   var intCuentaApostrofes=0;  
   var strtxtArticuloId = "";
   
   strtxtArticuloId = Trim(document.forms[0].elements['txtMarcaLider'].value);
       
   if (strtxtArticuloId.length< 1) {
       alert("Teclear Número de articulo o descripción");
       document.forms[0].elements['txtMarcaLider'].focus();
       return(false);
   }
        
   intCuentaApostrofes = strtxtArticuloId.search("'");
      
   if (intCuentaApostrofes != -1) {
       document.forms[0].elements['txtMarcaLider'].value = '';
              
       alert("No se deben de capturar apostrofes");
       
       document.forms[0].elements['txtMarcaLider'].focus();
       return(false);
   }
   
   if (document.forms[0].elements['hdnMarcaLider'].value == document.forms[0].elements['txtMarcaLider'].value) {	       
      return(true);   
   }
      
   if (isNaN(strtxtArticuloId)) // Esta capturando Descripcion
   {        
      strParametros = ''		      
      strParametros = strParametros + '&strArticuloIdNombre=' + document.forms[0].elements['txtMarcaLider'].value;
      strParametros = strParametros + '&strArticulo=txtMarcaLider';
      strParametros = strParametros + '&strArticuloNombreId=txtArticuloLider';
      strEvalJs='opener.fnLupaArticuloLider();' ;
            	  			       
      Pop('../_ScriptLibrary/PopArticulo.aspx?blnSucursal=false'+strParametros+'&strEvalJs='+strEvalJs,500,540);       
   }   
   else {
       document.forms[0].elements['hdnMPoML'].value = '1'
       document.forms[0].action = '<%=strFormAction%>?strCmd=BuscarArticulo';
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target='';   
  }  
  
}	
	
function fnLupaArticulo() {
 if(!isNaN(document.forms[0].elements['txtMarcaPropia'].value)){
    document.forms[0].elements['hdnMarcaPropia'].value = document.forms[0].elements['txtMarcaPropia'].value;
 }
 else {
    document.forms[0].elements['txtMarcaPropia'].value='';
    document.forms[0].elements['hdnMarcaPropia'].value='';
    document.forms[0].elements['txtArticuloDescripcion'].value='';
    document.forms[0].elements['hdnMPoML'].value = '0'
    document.forms[0].elements["txtMarcaPropia"].focus()
 }
}

function fnLupaArticuloLider() {
 if(!isNaN(document.forms[0].elements['txtMarcaLider'].value)){
    document.forms[0].elements['hdnMarcaLider'].value = document.forms[0].elements['txtMarcaLider'].value;
 }
 else {
    document.forms[0].elements['txtMarcaLider'].value='';
    document.forms[0].elements['hdnMarcaLider'].value='';
    document.forms[0].elements['txtArticuloLider'].value='';
    document.forms[0].elements['hdnMPoML'].value = '0'
    document.forms[0].elements["txtMarcaLider"].focus()
 }

}

function fnUpBuscarArticulo(intError,intMPoML,intArticuloId,strArticuloDescripcion) {
    if(intError == 0){
		if(intMPoML == 0){ 
        document.forms[0].elements['hdnMarcaPropia'].value = intArticuloId;     	
		document.forms[0].elements['txtMarcaPropia'].value = intArticuloId;
	    document.forms[0].elements['txtArticuloDescripcion'].value = strArticuloDescripcion;
	    document.forms[0].elements['hdnMPoML'].value = '0'
	    document.forms[0].elements['txtMarcaLider'].focus();
	    }
	    else{
        document.forms[0].elements['hdnMarcaLider'].value = intArticuloId;     	
		document.forms[0].elements['txtMarcaLider'].value = intArticuloId;
	    document.forms[0].elements['txtArticuloLider'].value = strArticuloDescripcion;
	    document.forms[0].elements['hdnMPoML'].value = '0'
	    document.forms[0].elements['cmdAgregar'].focus();	    
	    }
	}
	else{		
		if(intMPoML == 0){
		document.forms[0].elements['hdnMarcaPropia'].value = '';				
		document.forms[0].elements['txtMarcaPropia'].value = '';				
		document.forms[0].elements['txtArticuloDescripcion'].value='';
		document.forms[0].elements['hdnMPoML'].value = '0'
		document.forms[0].elements['txtMarcaPropia'].focus();
		}
		else{
        document.forms[0].elements['hdnMarcaLider'].value = '';     	
		document.forms[0].elements['txtMarcaLider'].value = '';
	    document.forms[0].elements['txtArticuloLider'].value = '';
	    document.forms[0].elements['hdnMPoML'].value = '0'
	    document.forms[0].elements['txtMarcaLider'].focus();	    
		}
		alert("Articulo no encontrado");
	}
}	 

function cmdAgregar_onclick() {
  if (document.forms[0].elements["txtMarcaPropia"].value.length < 1) {
    alert("Por favor especifique un valor para el campo \"Marca Propia\".");
    document.forms[0].elements["txtMarcaPropia"].focus();
    return(false);
  }
  if (document.forms[0].elements["txtMarcaLider"].value.length < 1) {
    alert("Por favor especifique un valor para el campo \"Marca Líder\".");
    document.forms[0].elements["txtMarcaLider"].focus();
    return(false);
  } 
  if (document.forms[0].elements["txtMarcaPropia"].value == document.forms[0].elements["txtMarcaLider"].value ){
    alert("El valor del campo \"Marca Propia\" y el campo \"Marca Líder\" son iguales, favor de verificar.");
    document.forms[0].elements["txtMarcaLider"].focus();
	return(false);
  }
  document.forms[0].action = '<%=strFormAction%>?strCmd=Agregar';
  document.forms[0].target="ifrOculto";
  document.forms[0].submit();
  document.forms[0].target='';     
}

function cmdLimpiar_onclick() {
   document.forms[0].action = '<%=strFormAction%>?intNavegadorRegistrosPagina=1';
   document.forms[0].target='';  
   document.forms[0].submit();
}

function fnUpAgregarActualizar(intError,strComando) {
	if(intError > 0){
		alert("La información se guardo con éxito.");		
	}
	else{
		if(intError > -100){
			alert("Los artículos capturados no fueron encontrados.");
		}
	}	
	document.forms[0].elements['hdnMarcaPropia'].value = '';     	
    document.forms[0].elements['txtMarcaPropia'].value = '';
    document.forms[0].elements['txtArticuloDescripcion'].value = '';
    document.forms[0].elements['hdnMPoML'].value = '0';
    document.forms[0].elements['hdnMarcaLider'].value = '';     	
    document.forms[0].elements['txtMarcaLider'].value = '';
    document.forms[0].elements['txtArticuloLider'].value = '';
    document.forms[0].elements['txtMarcaPropia'].focus();
    
    cmdLimpiar_onclick();
}	 

</script>
</HEAD>
<body language=javascript onLoad="return window_onload()">
<form name="frmMain" action="about:blank" method="post">
  <input type="hidden" value="0" name="hdnMarcaPropia">
  <input type="hidden" value="0" name="hdnMarcaLider">
  <input type="hidden" value="0" name="hdnMPoML">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : <a href="SucursalHome.htm">Sucursal</a> : <a href="../_Manager/SucursalSenalizacionAdministracionMarcaPropia.aspx">Administración marca propia</a> </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Administración productos marca FASA vs. productos líderes</h1>
		<p>En esta parte se consultan, modifican y agregan las parejas de productos marca propia vs.  
          líderes para señalización en sucursales.</p>
		<table style="width:100%;">
			<tr>
				<td class="tdtexttablebold" style="width:100px;"><span>Marca propia:</span></td>
				<td class="tdtexttablebold">
					<input language="javascript" class="field" id="txtMarcaPropia" name="txtMarcaPropia"  onblur="return txtMarcaPropia_onblur()"  onkeydown="return txtMarcaPropia_onkeydown(event)" type="text" maxLength="13" size="8"  autocomplete="off" value='<%=Request("txtMarcaPropia")%>'>
					<a id="objLupaArticulo">
						<img height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0" />
					</a>
					<input type="text" language="javascript" class="campotablaresultado" id="txtArticuloDescripcion" name="txtArticuloDescripcion" size="40" readOnly border="0" value='<%=Request.Form("txtArticuloDescripcion")%>' />
				</td>
			</tr>
			<tr>
				<td class="tdtexttablebold"><span>Líder:</span></td>
				<td class="tdtexttablebold">
					<input language="javascript"  class="field" id="txtMarcaLider" name="txtMarcaLider" onblur="return txtMarcaLider_onblur()"  onkeydown="return txtMarcaLider_onkeydown(event)" type="text" maxLength="13" size="8"  autocomplete="off" value='<%=Request("txtMarcaLider")%>'/>
					<a id="objLupaArticuloLider">
						<img height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0" />
					</a>
					<input type="text" language="javascript" class="campotablaresultado" id="txtArticuloLider" name="txtArticuloLider" size="40" readOnly border="0" value='<%=Request.Form("txtArticuloLider")%>' />
				</td>
			</tr>
		</table>
		<P>
		<input class="button" id="cmdAgregar" name="cmdAgregar" value="Agregar" onclick="return cmdAgregar_onclick()" type="button">		
		&nbsp;</P>
		<%=  strGetRecordBrowserHTML() %>
		<br>
		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
				<td align="right" width="90%"><input language="javascript" class="button" id="cmdRegresar" onclick="return cmdCancelar_onclick()"
						type="button" value="Regresar" name="cmdRegresar">
				</td>
				<td align="right" width="10%"><input language="javascript" class="button" id="cmdImprimir" onclick="return cmdImprimir_onclick()"
						type="button" value="Imprimir" name="cmdImprimir">
				</td>
			</tr>
		</table>
      </td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaFooterCentral()</script></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
</script>
</form>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
</body>
</HTML>

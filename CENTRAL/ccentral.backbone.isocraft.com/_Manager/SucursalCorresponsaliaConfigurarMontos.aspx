<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalCorresponsaliaConfigurarMontos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalCorresponsaliaConfigurarMontos"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<LINK href="css/menu.css" type="text/css" rel="stylesheet">
			<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
				<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
				<script language="javascript" id="clientEventHandlersJS">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
<%= strJavascriptWindowOnLoadCommands %>
<%= strLlenarBancoIntegradorComboBox %>
<%= strLlenarTipoServicioComboBox() %>
<%= strLlenarFormaPagoComboBox() %>


if("<%=intBancoIntegradorId%>" <= 0){
	document.all('cmdGuardarMontos').style.display="none";
    document.all('cmdGuardarMontosCashBack').style.display="none";
	document.all('cmdCancelar').style.display="none";
	document.all('cmdCancelar2').style.display="none";
	document.all('tituloMin').style.display="none";
	document.all('tituloMax').style.display="none";
	document.all('tblMontoMinimo').style.display="none";
	document.all('tblMontoMaximo').style.display="none";
	document.all('tituloComision').style.display="none";
	document.all('txtMontoComision').style.display="none";
	document.forms[0].elements["cboTipoServicio"].selectedIndex = 0;
	document.all("cboFormaPago").selectedIndex=0;
  }else{  
	if("<%=intBancoIntegradorId%>"!=2){	
		document.all('txtMontoComision').disabled=true;
	}else{
		if("<%=intTipoServicioId%>"==1 || "<%=intTipoServicioId%>"==4){
			document.all('txtMontoComision').disabled=true;
		}
	}
  	document.all('cmdGuardarMontos').style.display="inline";
	document.all('cmdGuardarMontosCashBack').style.display="inline";
	document.all('cmdCancelar').style.display="inline";
	document.all('cmdCancelar2').style.display="inline";
	document.all('tituloMin').style.display="inline";
	document.all('tituloMax').style.display="inline";
	document.all('tblMontoMinimo').style.display="inline";
	document.all('tblMontoMaximo').style.display="inline";
	document.all('tblMontoMaximo').style.display="inline";
	document.all('tituloComision').style.display="inline";		
  }
  
}

function cmdGuardarMontos_onclick() {
       
       if (ValidarMontos()){
         if ((document.forms[0].cboTipoServicio.value != 0) &&
             (document.forms[0].cboFormaPago.value != 0)) {
         document.forms[0].action += "?strCmd=Salvar";
         document.forms(0).submit();
         }
       }       
}

function cmdGuardarMontosCashBack_onclick() {
       if (ValidarMontosCashBack()){
         document.forms[0].action += "?strCmd=SalvarCash";
         document.forms(0).submit();
       }
        
}

function ValidarMontosCashBack(){
 
  var Monto1 = 0;
  var Monto2 = 0;
  var Monto3 = 0;
  var NivelEfectivo = 0;
  var blnReturn = false;
 
  Monto1 = parseFloat(document.forms[0].txtMontoPOS1.value);
  Monto2 = parseFloat(document.forms[0].txtMontoPOS2.value);
  Monto3 = parseFloat(document.forms[0].txtMontoPOS3.value);
  NivelEfectivo = parseFloat(document.forms[0].txtNivelEfectivo.value);
    
    if ((blnValidarCampo(document.forms[0].elements["txtMontoPOS1"], true, "Monto POS 1", cintTipoCampoAlfanumerico, 50, 1, "") == true) &&
       (blnValidarCampo(document.forms[0].elements["txtMontoPOS2"], true, "Monto POS 2", cintTipoCampoAlfanumerico, 50, 1, "") == true)  && 
       (blnValidarCampo(document.forms[0].elements["txtMontoPOS3"], true, "Monto POS 3", cintTipoCampoAlfanumerico, 50, 1, "") == true) &&
       (blnValidarCampo(document.forms[0].elements["txtNivelEfectivo"], true, "Nivel de Efectivo en POS", cintTipoCampoAlfanumerico, 50, 1, "") == true))
    {
     
       if ((checkDecimals(document.forms[0].elements["txtMontoPOS1"],document.forms[0].elements["txtMontoPOS1"].value,"Monto POS 1")== true) && 
           (checkDecimals(document.forms[0].elements["txtMontoPOS2"],document.forms[0].elements["txtMontoPOS2"].value,"Monto POS 2")== true) &&
           (checkDecimals(document.forms[0].elements["txtMontoPOS3"],document.forms[0].elements["txtMontoPOS3"].value,"Monto POS 3")== true) &&
           (checkDecimals(document.forms[0].elements["txtNivelEfectivo"],document.forms[0].elements["txtNivelEfectivo"].value,"Nivel de Efectivo en POS")== true))
           {
                
                if( (Monto1 >= NivelEfectivo) || (Monto2 >= NivelEfectivo) || (Monto3 >= NivelEfectivo) ){    
                   alert("El nivel de Efectivo en POS debe ser mayor que cualquier monto a ofrecer!");
				}else{
				
					blnReturn = true;	
						
                      if ((Monto1 >= Monto2) ){
				         alert("El monto 1 debe ser menor al monto 2!");
				         blnReturn = false;
				      }
				      if ((Monto2 >= Monto3) ){
				         alert("El monto 2 debe ser menor al monto 3!");
				         blnReturn = false;
				      }							
				}
				
		   }
     }     
     	 
       return blnReturn;
   } 

 
 function ValidarMontos(){
 
  var MontoMinimo = 0;
  var MontoMaximo = 0;
  
  MontoMinimo = parseFloat(document.forms[0].txtMontoMinimo.value);
  MontoMaximo = parseFloat(document.forms[0].txtMontoMaximo.value);
  
  var blnReturn = false;
    if ((blnValidarCampo(document.forms[0].elements["txtMontoMinimo"], true, "Monto Mínimo", cintTipoCampoAlfanumerico, 50, 1, "") == true) &&
       (blnValidarCampo(document.forms[0].elements["txtMontoMaximo"], true, "Monto Máximo", cintTipoCampoAlfanumerico, 50, 1, "") == true) )
    {
    
       if ((checkDecimals(document.forms[0].elements["txtMontoMinimo"],document.forms[0].elements["txtMontoMinimo"].value,"Monto Mínimo")== true) && 
           (checkDecimals(document.forms[0].elements["txtMontoMaximo"],document.forms[0].elements["txtMontoMaximo"].value,"Monto Máximo")== true) )
           {
                if(MontoMinimo >= MontoMaximo){
                   if(MontoMinimo==0 && MontoMaximo==0){
                   	blnReturn = true;				
                   }else{    
                   alert("El monto mínimo no debe ser mayor o igual al máximo!");
                   }
				}else{
					blnReturn = true;				
				}
				
		   }
     }      
		if("<%=intBancoIntegradorId%>"==2 ){	
		   if (document.all("cboTipoServicio").value!=1 && document.all("cboTipoServicio").value!=4) { 
			if(blnReturn==true)
			{ 
				blnReturn = false
				if ((blnValidarCampo(document.forms[0].elements["txtMontoComision"], true, "Monto Comisión", cintTipoCampoAlfanumerico, 50, 1, "") == true))
				{    
						if ((checkDecimals(document.forms[0].elements["txtMontoComision"],document.forms[0].elements["txtMontoComision"].value,"Monto Comisión")== true))
						{
									if(document.forms[0].elements["txtMontoComision"].value>=0){
                   						blnReturn = true;				
									}else{    
										blnReturn = false;
									}								
						}
				} 
			} 
		}
	 }
       return blnReturn;
   }      
   
 //Valida que se ingresen solo numeros con dos decimales maximo
function checkDecimals(fieldName, fieldValue, campo) {

  decallowed = 2;  // Que tantos decimales son permitidos?

  if (isNaN(fieldValue) || fieldValue == "") {
	alert("Por favor introduce un valor numérico en el campo \"" + campo + "\".");
	fieldName.select();
	fieldName.focus();
	return(false)
  }
  else {
    if (fieldValue.indexOf('.') == -1) fieldValue += ".";
    dectext = fieldValue.substring(fieldValue.indexOf('.')+1, fieldValue.length);
	if (dectext.length > decallowed)
	{
	  alert("El valor del campo \"" + campo + "\", debe tener a lo más " + decallowed + " decimales.");
	  fieldName.select();
	  fieldName.focus();
	  return(false);
    }
	else {
	  return(true);
    }
  }
}
 
 function cmdCancelar_onclick() {
   window.location.href = "SucursalCorresponsaliaServicios.aspx";
 }

function cboBancoIntegrador_onchange(){
	document.forms(0).submit();
	return(true)
}
function cboTipoServicio_onchange(){
if("<%=intBancoIntegradorId%>"==2 ){
	if(document.all("cboTipoServicio").value==1 || document.all("cboTipoServicio").value==4){
		document.all('txtMontoComision').disabled=true;
	}else{
		document.all('txtMontoComision').disabled=false;
	}
}else{
	document.all('txtMontoComision').disabled=true;
}
}
//-->
				</script>
	</HEAD>
	<body onload="window_onload()">
		<form name="frmSucursalCorresponsaliaConfigurarMontos" action="about:blank" method="post">
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td>
						<script language="JavaScript">crearTablaHeader()</script>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td class="tdtab" width="770">Está en : Sucursal : Corresponsalía : Configuración 
						de Montos
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent"><h1>Configuración de Montos</h1>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="tdtexttablebold" width="25%">Banco:</td>
								<td class="tdpadleft5" width="15%">
									<select class="campotabla" id="cboBancoIntegrador" name="cboBancoIntegrador" language="javascript" onchange="return cboBancoIntegrador_onchange()">
										<option value="0" selected>» Elija un Banco Corresponsalia «</option>
									</select>
								</td>								
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="25%">Tipo de Servicio:</td>
								<td class="tdpadleft5" width="25%"><select class="campotabla" id="cboTipoServicio" name="cboTipoServicio" language="javascript" onchange="return cboTipoServicio_onchange()">
										<option value="0" selected>» Elija un Tipo de Servicio «</option>
									</select>
								</td>
								<td class="tdtexttablebold" id="tituloMin" vAlign="bottom" align="right" width="25%" colSpan="1" rowSpan="1">Mínimo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
								<td class="tdtexttablebold" id="tituloMax"vAlign="bottom" align="center" width="25%" colSpan="1" rowSpan="1">Máximo</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="25%">Forma de Pago:</td>
								<td class="tdpadleft5" width="25%"><select class="campotabla" id="cboFormaPago" name="cboFormaPago">
										<option value="0" selected>» Elija una Forma de Pago «</option>
									</select>
								</td>
								<td align="right" id="tblMontoMinimo"><input class="field" id="txtMontoMinimo" type="text" maxLength="10" size="10" name="txtMontoMinimo">
								</td>
								<td align="center" id="tblMontoMaximo"><input class="field" id="txtMontoMaximo" type="text" maxLength="10" size="10" name="txtMontoMaximo">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" id="tituloComision" width="25%">Comisión:</td>
								<td class="tdpadleft5"><input class="field" id="txtMontoComision" type="text" maxLength="10" size="10" name="txtMontoComision"></td>
							</tr>
						</table>
						<br>
						<br>
						<input class="button" onclick="return cmdCancelar_onclick()" type="button" value="Regresar"	name="cmdCancelar" onclick="return cmdCancelar_onclick()"> 
						<input class="button" onclick="return cmdGuardarMontos_onclick()" type="button" value="Guardar Montos" name="cmdGuardarMontos" onclick="return cmdGuardarMontos_onclick()">
						<table cellSpacing="0" cellPadding="0" width="50%" border="0">
							<tr>
								<td width="30%"><%= ArmarRecordBrowsers() %></td>
							</tr>
						</table>
						<br>
						<table cellSpacing="0" cellPadding="0" width="60%" border="0">
							<tr>
								<td width="30%"><%= strCashBackRecordBrowserHTML() %></td>
							</tr>
						</table>
						<br>
						<input class="button" onclick="return cmdCancelar_onclick()" type="button" value="Regresar"	name="cmdCancelar2" onclick="return cmdCancelar_onclick()"> 
						<input class="button" onclick="return cmdGuardarMontosCashBack_onclick()" type="button" value="Guardar Montos CashBack" name="cmdGuardarMontosCashBack" onclick="return cmdGuardarMontosCashBack_onclick()">
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
	</body>
</HTML>

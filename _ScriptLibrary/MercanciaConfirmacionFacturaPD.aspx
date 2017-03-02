<!--codePage="28592" -->
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaConfirmacionFacturaPD.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaConfirmacionFacturaPD" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
			'====================================================================
			' Page          : MercanciaConfirmacionFacturaPD.aspx
			' Title         : Administracion POS y BackOffice
			' Description   : Página donde confirma las Facturas Electronicas de Proveedores Directos
			' Copyright     : 2012 All rights reserved.
			' Company       : Benavides
			' Consulting C. : Softtek
			' Author        : Victor Ollervides [VHOV]
			' Version       : 1.0
			' Created		: 14 de Junio de 2012
			' Last Modified : 
			'==================================================================== 
		%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link href="../static/css/menu.css" rel="stylesheet">
<link href="../static/css/menu2.css" rel="stylesheet">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/tools.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
		<!--

			function window_onload() 
			{
				MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
				document.forms[0].action = "<%=strFormAction%>";
				
				var strMensaje	  = "<%=strMensaje%>";
				var strConfirmada = "<%=strConfirmada%>";
				var strError	  = "<%=strError%>";	
				
				document.forms[0].elements['dtmRecepcionFactura'].value = "<%=dtmRecepcionFacturaCapturada%>";
				document.forms[0].elements['txtNumeroFactura'].value = "<%=strNumeroFacturaCapturada%>";
				document.forms[0].elements['dtmEmisionFactura'].value = "<%=dtmEmisionFacturaCapturada%>";
				document.forms[0].elements['txtMontoNetoFactura'].value = "<%=dblMontoNetoCapturado%>";
				document.forms[0].elements['txtNotaEntrada'].value = "<%=intNotaEntradaCapturada%>";
				
				var strRemisionCompraDirectaNumeroDocumento = "";
				strRemisionCompraDirectaNumeroDocumento = "<%=strRemisionCompraDirectaNumeroDocumento%>"
				
				if( strRemisionCompraDirectaNumeroDocumento	!= "" )
				{
					document.forms[0].elements['txtNumeroFactura'].disabled		= true;
					document.forms[0].elements['dtmEmisionFactura'].disabled	= true;
					document.forms[0].elements['txtMontoNetoFactura'].disabled	= true;								
				}
				
				else if( strRemisionCompraDirectaNumeroDocumento == "" )
				{
					document.forms[0].elements['txtNotaEntrada'].disabled = true;
				}		
						
						
				if (strMensaje.length > 0) 
				{
					alert(strMensaje);
				}
					
				if( strError.length > 0 )
				{
					document.getElementById( 'divError' ).outerHTML = "<br><br> <div class='txtitulo' align='center'> " 
																		+ "La factura no se puede confirmar debido a que se genero con el siguiente error: " 
																		+ "<br> <br>" + strError 
																	  + "</div>" ; 
					
					// Se deshabilitan todos los controles...
					document.forms[0].elements['cmdValidar'].disabled			= true;
					document.forms[0].elements['cmdConfirmar'].disabled			= true;
								
					document.forms[0].elements['dtmRecepcionFactura'].readOnly	= true;
					document.forms[0].elements['txtNumeroFactura'].readOnly		= true;
					document.forms[0].elements['dtmEmisionFactura'].readOnly	= true;
					document.forms[0].elements['txtMontoNetoFactura'].readOnly	= true;	
					document.forms[0].elements['txtNotaEntrada'].readOnly		= true;
						
					//document.getElementById( 'divCalendar1' ).disabled = true;	
					document.getElementById( 'calendarioRecepcionFactura' ).outerHTML = "<IMG id=calendarioRecepcionFactura border=0 alt='Clic para seleccionar la fecha.' src='../static/images/icono_calendario.gif' width=20 height=13>";
					document.getElementById( 'calendarioRecepcionFactura' ).disabled = true;
					
							
				}
				
				if( strConfirmada.length > 0 ) 
				{ 
					//Operacion Confirmada con exito
					document.forms[0].elements['cmdConfirmar'].disabled			= true;
					document.forms[0].elements['dtmRecepcionFactura'].readOnly	= true;
					document.forms[0].elements['txtNumeroFactura'].readOnly		= true;
					document.forms[0].elements['dtmEmisionFactura'].readOnly	= true;
					document.forms[0].elements['txtMontoNetoFactura'].readOnly	= true;
					document.forms[0].elements['txtNotaEntrada'].readOnly		= true;
					
					strConfirmacion = '<%=intConfirmacion%>';
					strFechaHora 	= '<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>';
					
					document.all.divFolioConfirmacion.innerHTML = 'La operación quedo confirmada con el folio: '+strConfirmacion + '  con fecha: '+strFechaHora;
					
					//Mandar Imprimir
					cmdValidar_onclick();
					cmdImprimir_onclick();
				}
					
				return(true);
			}

			function strCompaniaSucursal() {
				document.write(<%=intCompaniaId%> + " - " + <%=intSucursalId%>);
				return(true);
			}
			function strSucursalNombre() {
				document.write("&nbsp;"+"<%=strSucursalNombre%>");
				return(true);
			}
			function strGetCustomDateTime() {
				document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
				return(true);
			}
			function strUsuarioNombre() {
				document.write("<%=strUsuarioNombre%>");
				return(true);
			}
			function strSucursalNombre() {
				document.write("&nbsp;"+"<%=strSucursalNombre%>");
				return(true);
			}

			function intProveedorId() {
			document.write("<%=intProveedorId%>");
			return(true);
			}
			function strProveedorRazonSocial() {
			document.write ("<%=strProveedorRazonSocial%>");
			}
			function strPedido() {
			document.write ("<%=intFacturaElectronicaPedido%>");
			}

			function intRemisionCompraDirectaFolio() {
				document.write("<%=intRemisionCompraDirectaFolio%>");
				return(true);
			}
			function strRemisionCompraDirectaNumeroDocumento() {
				document.write("<%=strRemisionCompraDirectaNumeroDocumento%>");
				return(true);
			}	
			
			
			
			
			
			
			
			
			
			
			function frmMercanciaConfirmacionFacturaPD_onsubmit() 
			{				
				var regreso = true;
			
				var strRemisionCompraDirectaNumeroDocumento = "";
				strRemisionCompraDirectaNumeroDocumento = "<%=strRemisionCompraDirectaNumeroDocumento%>"
				
				if( strRemisionCompraDirectaNumeroDocumento	!= "" )
				{
					if (regreso) 
					{
						if (document.forms[0].elements['txtNotaEntrada'].value == "")
						{
							alert("Capturar la Nota de Entrada de la Factura");
							document.forms[0].elements['txtNotaEntrada'].focus();
							regreso = false;
						}
					}				
				
					if (regreso) 
					{
						if (document.forms[0].elements['dtmRecepcionFactura'].value == "")
						{
							alert("Capturar la Fecha de Recepción de la Factura");
							document.forms[0].elements['dtmRecepcionFactura'].focus();
							regreso = false;
						}
					}
										
					if (regreso) 
						regreso = blnValidarCampo(document.forms[0].elements['dtmRecepcionFactura'],true,'Fecha Recepción de la Factura',cintTipoCampoFecha,10,10,'');
						

					if (regreso)
					{				
						var intRemisionCompraDirectaFolio  = "<%=intRemisionCompraDirectaFolio%>";
						var strFacturaNotaEntrada  = document.forms[0].elements['txtNotaEntrada'].value;
							
						if ( strFacturaNotaEntrada == intRemisionCompraDirectaFolio ) 	
							regreso = true;
							
						else
						{
							alert("Datos no coinciden con Factura a Confirmar");
							regreso = false;	       
						}
					}						
				}
				
				else if( strRemisionCompraDirectaNumeroDocumento == "" )
				{
					if (regreso) 
					{
						if (document.forms[0].elements['dtmRecepcionFactura'].value == "")
						{
							alert("Capturar la Fecha de Recepción de la Factura");
							document.forms[0].elements['dtmRecepcionFactura'].focus();
							regreso=false;
						}
					}
						
					if (regreso) 
					{
						if (document.forms[0].elements['txtNumeroFactura'].value == "") 
						{
							alert("Capturar la Factura a Confirmar");
							document.forms[0].elements['txtNumeroFactura'].focus();
							regreso=false;
						}
					}
					
					if (regreso) 
					{
						if (document.forms[0].elements['dtmEmisionFactura'].value == "")
						{
							alert("Capturar la Fecha Emisión de la Factura");
							document.forms[0].elements['dtmEmisionFactura'].focus();
							regreso=false;
						}
					}
					
					if (regreso) 
					{
						if (document.forms[0].elements['txtMontoNetoFactura'].value == "")
						{
							alert("Capturar el Neto Facturado");
							document.forms[0].elements['txtMontoNetoFactura'].focus();
							regreso=false;
						}
					}
						
					if (regreso) 
						regreso = blnValidarCampo(document.forms[0].elements['dtmRecepcionFactura'],true,'Fecha Recepción de la Factura',cintTipoCampoFecha,10,10,'');
					
					if (regreso)
						regreso = blnValidarCampo(document.forms[0].elements['dtmEmisionFactura'],true,'Fecha Emisión de la Factura',cintTipoCampoFecha,10,10,'');
					
					if (regreso)
						regreso = blnValidarCampo(document.forms[0].elements['txtMontoNetoFactura'],true,'Monto Neto Facturado',cintTipoCampoReal,20,0,'');
						
					if (regreso)
					{
						var strFacturaElectronicaNumero  = "<%=strFacturaElectronicaNumero%>";
						var dtmFacturaElectronicaEmision = "<%=dtmFacturaElectronicaEmision%>";  
						var fltFacturaElectronicaNeto 	 = <%=fltFacturaElectronicaImporteNeto%>;
										
						var strFacturaNumero  = document.forms[0].elements['txtNumeroFactura'].value;
						var dtmFacturaEmision = document.forms[0].elements['dtmEmisionFactura'].value.substr(3,2)+"/"+document.forms[0].elements['dtmEmisionFactura'].value.substr(0,2)+"/"+document.forms[0].elements['dtmEmisionFactura'].value.substr(6,4);
						var fltFacturaNeto    = document.forms[0].elements['txtMontoNetoFactura'].value;
							
						var diferencia = Math.abs( fltFacturaElectronicaNeto - fltFacturaNeto );

						if ( strFacturaNumero == strFacturaElectronicaNumero && dtmFacturaEmision == dtmFacturaElectronicaEmision && diferencia <= 1) 
						{
							regreso = true;
						}
						
						else
						{
							alert("Datos no coinciden con Factura a Confirmar");
							regreso = false;	       
						}
					}
				}	
				
				
				return (regreso);
			}





			



			function cmdValidar_onclick() 
			{					
				var regreso = true;
			
				var strRemisionCompraDirectaNumeroDocumento = "";
				strRemisionCompraDirectaNumeroDocumento = "<%=strRemisionCompraDirectaNumeroDocumento%>"
				
				if( strRemisionCompraDirectaNumeroDocumento	!= "" )
				{
					if (regreso) 
					{
						if (document.forms[0].elements['txtNotaEntrada'].value == "")
						{
							alert("Capturar la Nota de Entrada de la Factura");
							document.forms[0].elements['txtNotaEntrada'].focus();
							regreso = false;
						}
					}				
				
					if (regreso) 
					{
						if (document.forms[0].elements['dtmRecepcionFactura'].value == "")
						{
							alert("Capturar la Fecha de Recepción de la Factura");
							document.forms[0].elements['dtmRecepcionFactura'].focus();
							regreso = false;
						}
					}
										
					if (regreso) 
						regreso = blnValidarCampo(document.forms[0].elements['dtmRecepcionFactura'],true,'Fecha Recepción de la Factura',cintTipoCampoFecha,10,10,'');
						

					if (regreso)
					{
						var intRemisionCompraDirectaFolio  = "<%=intRemisionCompraDirectaFolio%>";
						var strFacturaNotaEntrada  = document.forms[0].elements['txtNotaEntrada'].value;
							
						if ( strFacturaNotaEntrada == intRemisionCompraDirectaFolio ) 	
						{
							document.forms[0].elements['txtValidacion'].value 		   = "DATOS VALIDOS";	
							document.forms[0].elements['txtTotalFacturado'].value 	   = <%=fltFacturaElectronicaImporteTotal%>;
							document.forms[0].elements['txtIVAFacturado'].value 	   = <%=fltFacturaElectronicaImporteIVA%>;
							document.forms[0].elements['txtIVADescuento'].value 	   = <%=fltFacturaElectronicaImporteIVADescuento%>;
							document.forms[0].elements['txtDescuentoDespuesIVA'].value = <%=fltFacturaElectronicaImporteDescuentoDespuesIVA%>;
                            document.forms[0].elements['txtIEPSFacturado'].value       = "<% = fltFacturaElectronicaImporteIEPS()%>";
						}
						
						else
						{
							document.forms[0].elements['txtValidacion'].value 		   = "ERROR EN DATOS";	
							document.forms[0].elements['txtTotalFacturado'].value	   = "";
							document.forms[0].elements['txtIVAFacturado'].value 	   = "";
							document.forms[0].elements['txtIVADescuento'].value 	   = "";
							document.forms[0].elements['txtDescuentoDespuesIVA'].value = "";
							document.forms[0].elements['txtIEPSFacturado'].value       = "";
						}
					}						
				}
				
				else if( strRemisionCompraDirectaNumeroDocumento == "" )
				{					
					if( regreso ) 
					{
						if (document.forms[0].elements['dtmRecepcionFactura'].value == "")
						{
							alert("Capturar la Fecha de Recepción de la Factura");
							regreso = false;
						}
					}
						
					if( regreso ) 
					{   	
						if (document.forms[0].elements['txtNumeroFactura'].value == "") 
						{
							alert("Capturar la Factura a Confirmar");
							regreso = false;
						}
					}
						
					if( regreso ) 
					{
						if (document.forms[0].elements['dtmEmisionFactura'].value == "")
						{
							alert("Capturar la Fecha Emisión de la Factura");
							regreso = false;
						}
					}
						
					if( regreso ) 
					{
						if (document.forms[0].elements['txtMontoNetoFactura'].value == "")
						{
							alert("Capturar el Neto Facturado");
							regreso = false;
						}
					}
						
					if( regreso ) 
						regreso = blnValidarCampo( document.forms[0].elements['dtmRecepcionFactura'], true, 'Fecha Recepción de la Factura', cintTipoCampoFecha, 10, 10, '' );
							
					if( regreso )
						regreso = blnValidarCampo( document.forms[0].elements['dtmEmisionFactura'], true,'Fecha Emisión de la Factura', cintTipoCampoFecha, 10, 10, '' );
						
					if( regreso )
						regreso = blnValidarCampo( document.forms[0].elements['txtMontoNetoFactura'],true,'Monto Neto Facturado', cintTipoCampoReal, 20, 0, '' );
						
						
					if( regreso )
					{
						var strFacturaElectronicaNumero  = "<%=strFacturaElectronicaNumero%>";
						var dtmFacturaElectronicaEmision = "<%=dtmFacturaElectronicaEmision%>";  
						var fltFacturaElectronicaNeto 	 = <%=fltFacturaElectronicaImporteNeto%>;
										
						var strFacturaNumero  = document.forms[0].elements['txtNumeroFactura'].value;
						var dtmFacturaEmision = document.forms[0].elements['dtmEmisionFactura'].value.substr(3,2)+"/"+document.forms[0].elements['dtmEmisionFactura'].value.substr(0,2)+"/"+document.forms[0].elements['dtmEmisionFactura'].value.substr(6,4);
						var fltFacturaNeto    = document.forms[0].elements['txtMontoNetoFactura'].value;
							
						var diferencia = Math.abs( fltFacturaElectronicaNeto - fltFacturaNeto );
							
						if ( strFacturaNumero == strFacturaElectronicaNumero && dtmFacturaEmision == dtmFacturaElectronicaEmision && diferencia <= 1 ) 
						{
							document.forms[0].elements['txtValidacion'].value 		   = "DATOS VALIDOS";	
							document.forms[0].elements['txtTotalFacturado'].value 	   = <%=fltFacturaElectronicaImporteTotal%>;
							document.forms[0].elements['txtIVAFacturado'].value 	   = <%=fltFacturaElectronicaImporteIVA%>;
							document.forms[0].elements['txtIVADescuento'].value 	   = <%=fltFacturaElectronicaImporteIVADescuento%>;
							document.forms[0].elements['txtDescuentoDespuesIVA'].value = <%=fltFacturaElectronicaImporteDescuentoDespuesIVA%>;
                            document.forms[0].elements['txtIEPSFacturado'].value       = "<% = fltFacturaElectronicaImporteIEPS()%>";
						}
						
						else
						{
							document.forms[0].elements['txtValidacion'].value 		   = "ERROR EN DATOS";	
							document.forms[0].elements['txtTotalFacturado'].value	   = "";
							document.forms[0].elements['txtIVAFacturado'].value 	   = "";
							document.forms[0].elements['txtIVADescuento'].value 	   = "";
							document.forms[0].elements['txtDescuentoDespuesIVA'].value = "";
							document.forms[0].elements['txtIEPSFacturado'].value       = "";
						}
					}
				}
				
				
				return (regreso);				
			}

			
			
			
			
			
			
			

			function cmdRegresar_onclick() {
			window.location="MercanciaFacturasporConfirmarPD.aspx?intProveedorId="+ <%=intProveedorId%>;
			}

			function cmdImprimir_onclick() 
			{
/*			
				if (window.print) 
				{
					document.ifrPageToPrint.document.all.ToPrintTxtMigaja.innerHTML=document.all.ToPrintTxtMigaja.innerText;
					document.ifrPageToPrint.document.all.ToPrintTxtFecha.innerHTML=document.all.ToPrintTxtFecha.innerText;
					document.ifrPageToPrint.document.all.ToPrintTxtSucursal.innerHTML=document.all.ToPrintTxtSucursal.innerText;
					document.ifrPageToPrint.document.all.ToPrintHtmContenido.innerHTML=document.all.ToPrintHtmContenido.innerHTML;
				    
					//Ocultar Validar Datos en el frame oculto
					document.ifrPageToPrint.document.all.cmdValidar.style.display='none';
				    
					//Mostrar Tabla de firmas
					document.ifrPageToPrint.document.all.divFirmasHTML.style.display='';
				    
					document.ifrPageToPrint.focus();
					window.print();        
				} 
				else 
				{
					alert("Tu navegador no soporta la función: Print.")
				}
*/

				document.ifrPageToPrint.document.all.divContenido.innerHTML = document.all.divImpresionHTML.innerHTML;        
				document.ifrPageToPrint.focus();
				window.print(); 
				return(true);
												
			}

		//-->
		</script>
</HEAD>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form	name="frmMercanciaConfirmacionFacturaPD" onSubmit="return frmMercanciaConfirmacionFacturaPD_onsubmit()" action="about:blank" method="post">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98" width="100%"> <script language="JavaScript">
						crearTablaHeader()
					</script> </td>
    </tr>
    <tr> 
      <td valign="top" height="34" width="100%"> <img src="../static/images/pixel.gif" width="1" height="34"> 
      </td>
    </tr>
    <tr> 
      <td width="100%"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgcolor="#ffffff"> <img height="8" src="../static/images/pixel.gif" width="10"> 
            </td>
            <td class="tdmigaja" width="583"> <div id="ToPrintTxtMigaja"> <span class="txdmigaja"> 
                Está en: <a class="txdmigaja" href="Mercancia.aspx"> Mercancía	
                </a> : <a class="txdmigaja" href="MercanciaEntradas.aspx"> Entradas 
                </a> : <a href="MercanciaEntradasComprasDirectas.aspx" class="txdmigaja"> 
                Compras directas </a> : <a class="txdmigaja" href="MercanciaConfirmarFacturaElectronicaPD.aspx"> 
                Proveedores por Confirmar </a> : <a href="MercanciaConfirmarFacturaElectronicaPD.aspx" class="txdmigaja"> 
                Facturas pendientes </a>:Confirmar</span> </div></td>
            <td class="tdfechahora" width="182"> <script language="javascript">
									strGetCustomDateTime()
								</script> </td>
          </tr>
          <tr> 
            <td width="10">&nbsp; </td>
            <td class="tdtablacont" valign="top" width="583"> <span class="txtitulo"> 
              Solicitar confirmación de factura </span> <span class="txcontenido"> 
              Para confirmar, capture número, fecha e importe neto de la factura, 
              y luego oprima el botón validar. </span> <br> <span class="txsubtitulo"> 
              <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle"> 
              Identificar documento </span> <script language="JavaScript">
									crearDatosSucursal()
								</script> <div id="ToPrintHtmContenido"> 
                <table cellspacing="0" cellpadding="0" width="583" border="0">
                  <tr> 
                    <td class="tdconttablas" colspan="4" nowrap> <div id="divFolioConfirmacion"></div></td>
                  </tr>
                  <tr> 
                    <div id="divError"> </div>
                    <td class="tdtittablas">Proveedor:</td>
                    <td class="tdconttablas"> <span class="txconttablasrojo"> 
                      <script language="JavaScript">strProveedorRazonSocial()</script>
                      </span></td>
                  </tr>
                  
                  <tr> 
                    <td class="tdtittablas">Pedido:</td>
                    <td class="tdconttablas" valign="top"> <script language="JavaScript">strPedido()</script> 
                    </td>
                  </tr>
                  
                  <tr> 
                    <td class="tdtittablas">Remision:</td>
                    <td class="tdconttablas" valign="top"> <script language="JavaScript">strRemisionCompraDirectaNumeroDocumento()</script> 
                    </td>
                  </tr>
                  
                  <tr> 
                    <td class="tdtittablas" width="163"> Fecha de recepción </td>
                    <td class="tdpadleft5"> <input	class="campotabla" 
								type="text" 
								maxlength="10" 
								size="10" 
								name="dtmRecepcionFactura"> 
                      <!-- <div id="divCalendar1" runat="server"> -->
                      <a href="javascript:objdtmRecepcionFactura.popup();"> <img onClick="return blnValidarCampo(document.forms('frmMercanciaConfirmacionFacturaPD').elements('dtmRecepcionFactura'),false,'Fecha',cintTipoCampoFecha,10,10,'');"
									height="13" 
									alt="Clic para seleccionar la fecha." 
									src="../static/images/icono_calendario.gif" 
									width="20" 
									border="0"
									id="calendarioRecepcionFactura"> </a> 
                      <!-- </div> -->
                    </td>
                  </tr>
                  
                  <!--
                  <tr> 
                    <td class="tdtittablas">Nota Entrada:</td>
                    <td class="tdconttablas" valign="top"> <script language="JavaScript">intRemisionCompraDirectaFolio()</script> 
                    </td>
                  </tr>
                  -->
                  
                  <tr> 
                    <td class="tdtittablas">Nota Entrada:</td>
                    <td class="tdpadleft5"> <input class="campotabla" type="text" maxlength="20" size="30" name="txtNotaEntrada"> 
                    </td>
                  </tr>                  
                              
                  <tr> 
                    <td class="tdtittablas">No. de factura:</td>
                    <td class="tdpadleft5"> <input class="campotabla" type="text" maxlength="20" size="30" name="txtNumeroFactura"> 
                    </td>
                  </tr>
                  
                  <tr> 
                    <td class="tdtittablas">Fecha de factura:</td>
                    <td class="tdpadleft5"> <input class="campotabla" type="text" maxlength="10" size="10" name="dtmEmisionFactura"> 
                      <a href="javascript:objdtmEmisionFactura.popup();"><img onClick="return blnValidarCampo(document.forms('frmMercanciaConfirmacionFacturaPD').elements('dtmEmisionFactura'),false,'Fecha',cintTipoCampoFecha,10,10,'');"
															height="13" alt="Clic para seleccionar la fecha." src="../static/images/icono_calendario.gif" width="20" border="0"></a> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" height="40">Neto facturado:</td>
                    <td class="tdpadleft5"> <input class="campotabla" type="text" maxlength="20" size="20" name="txtMontoNetoFactura"> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" width="163">Total facturado:</td>
                    <td class="tdconttablas" width="410"> <input class="campotablaresultado" type="text" size="20" name="txtTotalFacturado" redonly="true"> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">IVA facturado:</td>
                    <td class="tdconttablas"> <input class="campotablaresultado" type="text" size="20" name="txtIVAFacturado" redonly="true"> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">IVA Descuento:</td>
                    <td class="tdconttablas" valign="top"> <input class="campotablaresultado" type="text" size="20" name="txtIVADescuento" redonly="true"> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Descuento despues del IVA:</td>
                    <td class="tdconttablas" valign="top"> <input class="campotablaresultado" type="text" size="20" name="txtDescuentoDespuesIVA"
														redonly="true"> </td>
                  </tr>
                    <tr> 
                    <td class="tdtittablas">IEPS facturado:</td>
                    <td class="tdconttablas" valign="top"> <input class="campotablaresultado" type="text" size="20" name="txtIEPSFacturado" redonly="true"> </td>
                  </tr>
                  <tr> 
                    <td height="10"> <input	class="boton" 
								onClick="return cmdValidar_onclick()" 
								type="button" 
								value="Validar datos"
								name="cmdValidar" 
								id="cmdValidar"> </td>
                    <td class="tdconttablasrojo"> <input	class="campotablaresultado" 
								type="text" 
								size="20" 
								name="txtValidacion" 
								redonly="true"> </td>
                  </tr>
                </table>
                <div id="divFirmasHTML" style="DISPLAY:none"> <br>
                  <br>
                  <br>
                  <br>
                  <br>
                  <br>
                  <table>
                    <tr> 
                      <td>_________________</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td>_________________</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td>_________________</td>
                    </tr>
                    <tr> 
                      <td class="tdtittablas" align="center">Nombre y Firma</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Nombre y Firma</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Nombre y Firma</td>
                    </tr>
                    <tr> 
                      <td class="tdtittablas" align="center">Chofer Repartidor</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Capturó Documento</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Gte. Sucursal</td>
                    </tr>
                  </table>
                  <br>
                  <table>
                    <tr> 
                      <td class="tdtittablas"> * Este documento no será válido 
                        sin el nombre y firma de autorización del representante 
                        del proveedor.* </td>
                    </tr>
                  </table>
                </div>
              </div>
              <!-- CERRAMOS div id="ToPrintHtmContenido" -->
              <br> <span class="txsubtitulo"> <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle"> 
              Procesar documento 
              
              </span> <br> 
              
				<input	class="boton" 
						onClick="return cmdRegresar_onclick()" 
						type="button" 
						value="Otra factura"
						name="cmdRegresar"> 
					
					&nbsp;&nbsp; 
					
				<input	class="boton" 
						type="submit" 
						value="Confirmar Factura" 
						name="cmdConfirmar"> 
						
					&nbsp;&nbsp; 
					
				<div id="divImpresionHTML" style="DISPLAY:none"> 
							
                <%=strImpresionCompra%> 
                <script language="JavaScript">
					crearTablaFirmaCompras()
				</script>
              </div>
              <input	class="boton" 
					type="button" 
					value="Imprimir" 
					name="cmdImprimir" 
					style="DISPLAY:none"
					onclick="return cmdImprimir_onclick()"> <br> </td>
            <td class="tdcolumnader" valign="top" width="182" rowspan="2">&nbsp; </td>
          </tr>
          <tr> 
            <td class="tdbottom" colspan="2"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
		new menu (MENU_ITEMS, MENU_POS);
		new menu (MENU_ITEMS2, MENU_POS2);
		var objdtmRecepcionFactura = new calendar1(document.forms['frmMercanciaConfirmacionFacturaPD'].elements['dtmRecepcionFactura']);
		var objdtmEmisionFactura = new calendar1(document.forms['frmMercanciaConfirmacionFacturaPD'].elements['dtmEmisionFactura']);
	//-->
	</script>
</form>
<!-- 
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe> 
-->
<iframe name="ifrPageToPrint" src="ifrPaginaenBlanco.aspx" width="0" height="0"></iframe>
</body>
</HTML>

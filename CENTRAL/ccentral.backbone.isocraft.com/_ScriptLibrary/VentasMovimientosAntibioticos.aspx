<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="VentasMovimientosAntibioticos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsVentasMovimientosAntibioticos" codePage="28592"  %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
'====================================================================
' Page          : VentasMovimientosAntibioticos.aspx
' Title         : Administracion POS y BackOffice
' Description   : Página que muestra desde el ADS las Movimientos de AMtibioticos.
' Copyright     : 2003-2006 All rights reserved.
' Company       : Servicios Operacionales Benavides
' Author        : 
' Version       : 1.0
' Last Modified : 15 de Julio, 2010
'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
'                 16 de Enero 2012 [JAHD]    0RDENAMIENTO DE CONSULTA PARA VENTAS
'====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/FuncionesString.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

function window_onLoad() 
{
    document.forms[0].action = "VentasMovimientosAntibioticos.aspx";
	
    document.forms[0].elements["txtSelected"].value = "<%= strSelected %>";
	
	if (document.forms[0].elements["txtSelected"].value == "TODOS") {
	    document.forms[0].elements["txtArticulo"].value = "TODOS";
	}

	<%= strLlenarTiposMovComboBox() %>

	document.forms[0].elements["cboTiposMov"].value = "<%= strTipoSelected %>";
	document.forms[0].elements["cboMovs"].value = "<%= strMovSelected %>";				
	document.forms[0].elements["txtDesde"].value = "<%= strFechaInicial %>";
	document.forms[0].elements["txtHasta"].value = "<%= strFechaFinal %>";  
	document.forms[0].elements["cboOrden"].value = "<%= intOrdenId %>";  
		
    if (document.forms[0].elements["cboTiposMov"].value != "251") {
	    document.all.tblOrdenConsulta.style.display='none';
    }
    else
    {
        document.all.tblOrdenConsulta.style.display='';
    }	  
	
		
    return(true); 
}		
            
function isEnterKey(evt) 
{
				if (!evt) 
				{ 
					evt = window.event
				} 
				else if (!evt.keyCode) 
				{
					evt.keyCode = evt.which
				}
				return (evt.keyCode == 13)
}

function txtArticulo_onblur() 
{
			    document.forms[0].elements['txtArticulo'].value = document.forms[0].elements['txtArticulo'].value.toUpperCase();
			        
				strArticuloCapturado = Trim(document.forms[0].elements['txtArticulo'].value); 
								
				if (strArticuloCapturado.length > 0 && strArticuloCapturado != '0' && strArticuloCapturado != 'TODOS') 
				{
					objLupaArticulo_onclick(); 
				}
				else 
				{      
					return true;
				}
}

function txtArticulo_onkeydown(objEvent) 
{
				if (isEnterKey(objEvent)) 
				{
					txtArticulo_onblur();
					return(false);
				}
}	
				
// Lupa para Buscar articulos
function objLupaArticulo_onclick() 
{
				var valida = true;   
				var intCuentaApostrofes=0;  
				var strtxtArticuloId = "";
				
				document.forms[0].elements['txtArticulo'].value = document.forms[0].elements['txtArticulo'].value.toUpperCase();
				   
				strtxtArticuloId = Trim(document.forms[0].elements['txtArticulo'].value);				       
			        
				intCuentaApostrofes = strtxtArticuloId.search("'");				      
				if (intCuentaApostrofes != -1) 
				{
					document.forms[0].elements['txtArticulo'].value = '';              
					alert("No se deben de capturar apostrofes");       
					document.forms[0].elements['txtArticulo'].focus();
					return(false);
				}
				
				if (strtxtArticuloId != 'TODOS' && strtxtArticuloId.length > 1) 
				{

					if (isNaN(strtxtArticuloId)  )  // Esta capturando Descripcion
					{        
						strParametros = ''		      
						strParametros = strParametros + '&strArticuloIdNombre=' + document.forms[0].elements['txtArticulo'].value;
						strParametros = strParametros + '&strArticulo=txtArticulo';
						strParametros = strParametros + '&strArticuloNombreId=txtArticuloDescripcion';
						strEvalJs='opener.fnLupaArticulo();' ;

						document.forms[0].action = '<%=strFormAction%>';         	  			       
						window.open('PopArticulos.aspx?' + strParametros +'&strEvalJs='+strEvalJs, 'Articulos','width=500,height=540,left=0,top=0,resizable=yes,scrollbars=auto,menubar=no,status=yes' );
						  
					}   
					else 
					{
						document.forms[0].action = '<%=strFormAction%>?strCmd=BuscarArticulo';
						document.forms[0].target="ifrOculto";
						document.forms[0].submit();
						document.forms[0].target='';   
					}				  
				}
}

function fnLupaArticulo() 
{
				document.forms[0].elements['txtArticulo'].value = document.forms[0].elements['txtArticulo'].value.toUpperCase();
				
				if(isNaN(document.forms[0].elements['txtArticulo'].value) && document.forms[0].elements['txtArticulo'].value != 'TODOS')
				{
					document.forms[0].elements['txtArticulo'].value='';
					document.forms[0].elements['txtArticuloDescripcion'].value='';
					document.forms[0].elements["txtArticulo"].focus()
				}
}

function fnUpBuscarArticulo(intError,intArticuloId,strArticuloDescripcion) 
{
				if(intError == 0)
				{
						document.forms[0].elements['txtArticulo'].value = intArticuloId;
						document.forms[0].elements['txtArticuloDescripcion'].value = strArticuloDescripcion;
						document.forms[0].elements['cmdAgregar'].focus();	    
				}
				else
				{		
						document.forms[0].elements['txtArticulo'].value = '';				
						document.forms[0].elements['txtArticuloDescripcion'].value='';
						document.forms[0].elements['txtArticulo'].focus();
						alert("Articulo no encontrado o articulo no es antibiotico");
				}
}	 

function cmdAgregar_onclick() 
{			
				if (document.forms[0].elements["txtArticulo"].value.length < 1) 
				{
					alert("Por favor especifique un valor para el campo \"Articulo\".");
					document.forms[0].elements["txtArticulo"].focus();
					return(false);
				}
				document.forms[0].elements['txtArticulo'].value = document.forms[0].elements['txtArticulo'].value.toUpperCase();
				
				if (document.forms[0].elements["txtArticulo"].value != 'TODOS' && document.forms[0].elements["txtArticulo"].value >0) 
				{
					document.forms[0].action = 'VentasMovimientosAntibioticos.aspx?strCmd=Agregar';
					document.forms[0].target="ifrOculto";
					document.forms[0].submit();
					document.forms[0].target='';     
				}
}

function fnUpAgregar(intArticuloId) 
{
			   var counter = 0;
			   
			   if (document.forms[0].elements['txtSelected'].value == 'TODOS') {
			   	document.forms[0].elements['txtSelected'].value = '';
			   }
			   
			   if (document.forms[0].elements['txtArticulo'].value != 'TODOS') {
			   
			    // Agrega todos excepto si alguno es igual al nuevo
				var articulos = document.forms[0].elements['txtSelected'].value.split(',');
				document.forms[0].elements['txtSelected'].value = '';
				for (var i in articulos)
				{					
						if (articulos[i] != intArticuloId)
						{
							if(document.forms[0].elements['txtSelected'].value == '')
								document.forms[0].elements['txtSelected'].value = articulos[i]; 
							else 
								document.forms[0].elements['txtSelected'].value = document.forms[0].elements['txtSelected'].value + ',' + articulos[i];
								
							counter = counter + 1
						}
				}			
				// Agrego el nuevo
				if (counter < 10)
					{
						if(document.forms[0].elements['txtSelected'].value == '')
							document.forms[0].elements['txtSelected'].value = intArticuloId; 
						else 
							document.forms[0].elements['txtSelected'].value = document.forms[0].elements['txtSelected'].value + ',' + intArticuloId;
					}				
	
				document.forms[0].elements['txtArticulo'].value = '';
				document.forms[0].elements['txtArticuloDescripcion'].value = '';
							
				document.forms[0].action = 'VentasMovimientosAntibioticos.aspx';
				document.forms[0].target='';  
				document.forms[0].submit();
			   }
			   else {
			       document.forms[0].elements['txtSelected'].value = 'TODOS'; 			
			   }			
			   
			   document.forms[0].elements['txtArticulo'].focus();
}

function fnEliminaArticulo(strArticuloId) 
{
				if (confirm('Esta seguro que desea eliminar este elemento?') == true) 
				{
					var articulos = document.forms[0].elements['txtSelected'].value.split(',');
					
					document.forms[0].elements['txtSelected'].value = '';
					for (var i in articulos)
					{						
						if (articulos[i] != strArticuloId)
						{
							if(document.forms[0].elements['txtSelected'].value == '')
								document.forms[0].elements['txtSelected'].value = articulos[i]; 
							else 
								document.forms[0].elements['txtSelected'].value = document.forms[0].elements['txtSelected'].value + ',' + articulos[i];
						}
					}
									
					document.forms[0].action = 'VentasMovimientosAntibioticos.aspx';
					document.forms[0].target='';  
					document.forms[0].submit();
				}
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
    return(true);				
}
			
function cmdRegresar_onclick() 
{
    strRedireccionaPOSAdmin('Ventas.aspx');
}

function cmdConsultar_onclick() 
{
	document.forms[0].elements['txtArticulo'].value = document.forms[0].elements['txtArticulo'].value.toUpperCase();			
    if(document.forms[0].elements["txtArticulo"].value =='TODOS') {
	    document.forms[0].elements["txtSelected"].value = document.forms[0].elements["txtArticulo"].value;
	}							
				
	var strparametros = "strSelected="  + document.forms[0].elements['txtSelected'].value  + 
                "&strTipoMovimientoAntibioticoId="  + document.forms[0].elements["cboTiposMov"].value +
                "&strIndicadorMovimiento="  + document.forms[0].elements["cboMovs"].value  +
				"&strOrdenId="  + document.forms[0].elements["cboOrden"].value  +
                "&strFechaInicial="  + document.forms[0].elements["txtDesde"].value  +
                "&strFechaFinal="  + document.forms[0].elements["txtHasta"].value ;
				
    document.all.tblConsulta.style.display='';								
	
	document.forms[0].action = "ifrVentasMovimientosAntibioticos.aspx?" + strparametros;
	document.forms[0].target="ifrVentas";
	document.forms[0].submit();
	document.forms[0].target='';   
}
			
function Consulta_onchange() {
    if (document.forms[0].elements["cboTiposMov"].value != "251") {
	    document.all.tblOrdenConsulta.style.display='none';
    }
    else
    {
        document.all.tblOrdenConsulta.style.display='';
    }
	
    document.all.tblConsulta.style.display='none';
}			

//-->
</script>
</HEAD>
<body leftMargin="0" topMargin="0" onload="return window_onLoad()" marginheight="0" marginwidth="0">
<form name="frmMain" action="about:blank" method="post">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98" width="100%"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td valign="top" height="34" width="100%"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td width="100%" > <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgColor="#ffffff"><IMG height="8" src="../static/images/pixel.gif" width="10"></td>
            <td class="tdmigaja" width="583"> <span class="txdmigaja">Está en 
              : </span><A class="txdmigaja" href="javascript:strRedireccionaPOSAdmin('Ventas.aspx')">Ventas</A> 
              <span class="txdmigaja">: Movimientos Antibioticos </span></td>
            <td class="tdfechahora" width="182"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td vAlign="top" width="583"><table cellSpacing="0" cellPadding="0" width="100%" border="0">
                <tr> 
                  <td class="tdtablacont1" ><span class="txtitulo">Movimientos 
                    de Antibióticos</span> <span class="txsubtitulo">En esta sección 
                    se consultan los movimientos de los artículos catalogados 
                    como antibióticos.<br>
                    </span> <script language="JavaScript">crearDatosSucursal()</script> 
                    <br> <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                      <tr> 
                        <td class="tdtittablas" width="10%"><span>Artículo:</span> 
                          <input language="javascript" class="campotabla" type="hidden" id="txtSelected" name="txtSelected" width="5"></td>
                        <td class="tdconttablas" width="80%"><input language="javascript" class="campotablamayusculas" id="txtArticulo" onblur="return txtArticulo_onblur()"
																			maxLength="13" size="20" name="txtArticulo" autocomplete="off"> 
                          <A id="objLupaArticulo" onclick="objLupaArticulo_onclick()"> 
                          <IMG height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0"> 
                          </A> <input class="campotablaresultado" id="txtArticuloDescripcion" readOnly size="40" border="0"
																			name="txtArticuloDescripcion"> 
                        </td>
                        <td width="10%"> <input class="boton" id="cmdAgregar" onclick="return cmdAgregar_onclick()" type="button"
																	value="Agregar" name="cmdAgregar"></td>
                      </tr>
                    </table>
                    <br> <span class="txsubtitulo"><IMG height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Productos 
                    seleccionados</span> <%= strArticulosRecordBrowserHTML() %> 
                    <br> <span class="txsubtitulo"><IMG height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Criterios 
                    Busqueda</span> <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                      <tr> 
                        <td class="tdtittablas" align="lefth" width="30%"><span>Tipos 
                          de Movimiento:</span></td>
                        <td class="tdtittablas" align="lefth" width="20%"><span>Movimiento:</span></td>
                        <td class="tdtittablas" align="lefth" width="25%"><span>Desde:</span></td>
                        <td class="tdtittablas" align="lefth" width="25%"><span>Hasta:</span></td>
                      </tr>
                      <tr> 
                        <td class="tdconttablas"><select class="campotabla" id="cboTiposMov" name="cboTiposMov" onChange="return Consulta_onchange()">
                            <option value="0" selected>- Todos -</option>
                          </select> </td>
                        <td class="tdconttablas" ><select class="campotabla" id="cboMovs" name="cboMovs" onChange="return Consulta_onchange()">
                            <option value="0" selected>- Todos -</option>
                            <option value="Ingreso">Ingreso</option>
                            <option value="Egreso">Egreso</option>
                          </select> </td>
                        <td class="tdconttablas" align="left"><input language="javascript" class="campotabla" id="txtDesde" maxLength="13" size="8" value="21/06/2010"
																			name="txtDesde" autocomplete="off"> 
                          <A href="javascript:cal1.popup()"><IMG height="17" src="../static/images/icono_calendario.gif" align="absMiddle" border="0"></A> 
                        </td>
                        <td class="tdconttablas" align="left"><input language="javascript" class="campotabla" id="txtHasta" maxLength="13" size="8" value="21/06/2010"
																			name="txtHasta" autocomplete="off"> 
                          <A href="javascript:cal2.popup()"><IMG height="17" src="../static/images/icono_calendario.gif" align="absMiddle" border="0"></A> 
                        </td>
                      </tr>
                    </table>
                    <table id="tblOrdenConsulta" cellSpacing="0" cellPadding="0" width="100%" border="0" style="DISPLAY: none">
                      <tr> 
                        <td class="tdtittablas" width="30%">Ordenar:</td>
                        <td class="tdconttablas" width="70%"valign="top"> <select name="cboOrden" class="campotabla" id="cboOrden" onchange="return Consulta_onchange()">
                            <option value="0">Articulo</option>
                            <option value="1">Folio</option>
                          </select> </td>
                      </tr>
                    </table>
                    <br> <table cellSpacing="0" cellPadding="0" width="100%" border="0" >
                      <tr> 
                        <td align="lefth" width="10%"><input language="javascript" class="boton" id="cmdRegresar" onClick="return cmdRegresar_onclick()" type="button" value="Regresar" name="cmdRegresar"> 
                          &nbsp; <input class="boton" id="cmdConsultar" onclick="return cmdConsultar_onclick()" type="button" value="Consultar" name="cmdConsultar"> 
                        </td>
                      </tr>
                    </table></td>
                </tr>
              </table></td>
            <td class="tdcolumnader" vAlign="top" width="182" >&nbsp;</td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td colspan="3"><table id="tblConsulta"  width="100%" border="0" cellpadding="0" cellspacing="0" style="DISPLAY: none">
                <tr> 
                  <td><iframe name="ifrVentas" id="ifrVentas" src="ifrVentasMovimientosAntibioticos.aspx" frameborder="0" width="100%" height="480" marginwidth="0" marginheight="0" > 
                    </iframe> </td>
                </tr>
              </table></td>
          </tr>
          <tr> 
            <td class="tdbottom" colSpan="3"><script language="JavaScript">crearTablaFooter()</script></td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
        var cal1 = new calendar1(document.forms['frmMain'].elements['txtDesde']);
        var cal2 = new calendar1(document.forms['frmMain'].elements['txtHasta']);
	//-->
			</script>
</form>
<iframe name="ifrOculto" src="about:blank" width="0" height="0"></iframe>
</body>
</HTML>

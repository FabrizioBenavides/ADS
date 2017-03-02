<%@ Page Language="vb" AutoEventWireup="false"  EnableSessionState="False" enableViewState="False" Explicit="True" Trace="False" Strict="True" CodeBehind="popVentasPromocionesMonederoDetalleArticulo.aspx.vb"      Inherits="com.isocraft.backbone.ccentral.popVentasPromocionesMonederoDetalleArticulo" codePage="28592" %>
<HTML>
<HEAD>
<title>popVentasPromocionesMonederoDetalleArticulo</title>
<%  '====================================================================
    ' Page          : popVentasPromocionesMonederoDetalleArticulo.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : 
    ' Copyright     : 2007
    ' Company       : Farmacias Benavides
    ' Author        : J.Antonio Hernandez    
    ' Last Modified : 01 de Noviembre 2007
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
<script language="JavaScript" src="../static/scripts/FuncionesString.js" type="text/JavaScript"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}

function window_onload() {
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
	document.forms[0].action = "<%=strFormAction%>";
	
   intOpcAct = "<%=intOpcAct%>";
     
   if (intOpcAct == "1") {       
       document.forms[0].elements['optAct1'].checked = true;  
	   document.forms[0].elements['txtArticuloId'].focus();  
   }
   if (intOpcAct == "2") {
       document.forms[0].elements['optAct2'].checked = true; 
	   document.forms[0].elements['txtArticulosArchivo'].focus(); 	      
   } 
   
   return(true);
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

function blnEntradaValida() {  

   if (document.forms[0].elements['optAct1'].checked==false && document.forms[0].elements['optAct2'].checked==false) {
       alert("Debe indicar un archivo origen o el código del articulo");
        return(false);
   }   
   
   if (document.forms[0].elements['optAct1'].checked) { // Actualizacion por captura de articulo
       if (document.forms[0].elements['hdnArticuloId'].value <1 ) {
           alert("Debe haberse capturado un articulo valido");
           document.forms[0].elements['txtArticuloId'].focus();
           return(false);
       }               
       var formato=/^[0-9]{1,2}$/;
       if( !(formato.test(document.forms[0].elements["dblPorcentaje"].value)) ) {
           alert("     El porcentaje debe ser Numérico 5-99     ");
           document.forms[0].elements["dblPorcentaje"].value = "";
           document.forms[0].elements["dblPorcentaje"].focus();
           return(false);
       }
   }
   
   if (document.forms[0].elements['optAct2'].checked) {// Actualizacion Carga de Archivo

       if (document.forms[0].elements["txtArticulosArchivo"].value.length == 0) {
           alert("Por favor especifique un valor para el campo \"Archivo\".");
           document.forms[0].elements["txtArticulosArchivo"].focus();
           return(false);
       }        
   }      
   
   return (true);      
}

function txtArticuloId_onkeydown(objEvent) {
  if (isEnterKey(objEvent)) {
    txtArticuloId_onblur();
    return(false);
  }
}


function txtArticuloId_onfocus() {
   document.forms[0].elements['optAct1'].checked = true;
   document.forms[0].elements['txtArticulosArchivo'].value='';   
}

function txtArticuloId_onblur() {
   
   strArticuloCapturado = Trim(document.forms[0].elements['txtArticuloId'].value); 

   if (strArticuloCapturado.length > 0 && strArticuloCapturado != '0') {
      
      if (document.forms[0].elements['hdnArticuloId'].value != document.forms[0].elements['txtArticuloId'].value) {      
           objLupaArticulo_onclick(); 
      }
      else {
           document.forms[0].elements["dblPorcentaje"].focus();
      }
   }
   else {      
      return true;
   }
}

// Lupa para Buscar articulos
function objLupaArticulo_onclick() {
   
   var valida = true;   
   var intCuentaApostrofes=0;  
   var strtxtArticuloId = "";
   
   strtxtArticuloId = Trim(document.forms[0].elements['txtArticuloId'].value);
       
   if (strtxtArticuloId.length< 1) {
       alert("Teclear Número de articulo o descripción");
       document.forms[0].elements['txtArticuloId'].focus();
       return(false);
   }
        
   intCuentaApostrofes = strtxtArticuloId.search("'");
      
   if (intCuentaApostrofes != -1) {
       document.forms[0].elements['txtArticuloId'].value = '';
              
       alert("No se deben de capturar apostrofes");
       
       document.forms[0].elements['txtArticuloId'].focus();
       return(false);
   }
   
   if (document.forms[0].elements['hdnArticuloId'].value == document.forms[0].elements['txtArticuloId'].value) {	       
      return(true);   
   }
      
   if (isNaN(strtxtArticuloId)) // Esta capturando Descripcion
   {        
      strParametros = ''		      
      strParametros = strParametros + '&strArticuloIdNombre=' + document.forms[0].elements['txtArticuloId'].value;
      strParametros = strParametros + '&strArticulo=txtArticuloId';
      strParametros = strParametros + '&strArticuloNombreId=txtArticuloDescripcion';
      strEvalJs='opener.fnLupaArticulo();' ;
            	  			       
      Pop('../_ScriptLibrary/PopArticulo.aspx?blnSucursal=false'+strParametros+'&strEvalJs='+strEvalJs,500,540);       
   }   
   else {
   
       if (document.forms[0].elements['optAct1'].checked==true) {
           intOpcAct = "1";    
       }
       if (document.forms[0].elements['optAct2'].checked==true) {
           intOpcAct = "2";    
       }
	   
       var parametrosInicio = '&intPromocionId=' + '<%=Request("intPromocionId")%>' + '&strPromocionNombre=' + '<%=Request("strPromocionNombre")%>' + '&dtmPromocionInicio=' + '<%=Request("dtmPromocionInicio")%>' + '&dtmPromocionFin=' + '<%=Request("dtmPromocionFin")%>';
       document.forms[0].action = '<%=strFormAction%>?strCmd=BuscarArticulo&intOpcAct=' + intOpcAct + parametrosInicio;
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target='';   
  }  
  
}	

function fnLupaArticulo() {
 if(!isNaN(document.forms[0].elements['txtArticuloId'].value)){
    document.forms[0].elements['hdnArticuloId'].value = document.forms[0].elements['txtArticuloId'].value;
    document.forms[0].elements["dblPorcentaje"].focus();    
 }
 else {
    document.forms[0].elements['txtArticuloId'].value='';
    document.forms[0].elements['hdnArticuloId'].value='';
    document.forms[0].elements['txtArticuloDescripcion'].value='';
    document.forms[0].elements["txtArticuloId"].focus()
 }

}

function fnUpBuscarArticulo (intError,intArticuloId,strArticuloDescripcion) {  

    if(intError == 0){
        document.forms[0].elements['hdnArticuloId'].value = intArticuloId;     	
		document.forms[0].elements['txtArticuloId'].value = intArticuloId;
	    document.forms[0].elements['txtArticuloDescripcion'].value = strArticuloDescripcion;
	    document.forms[0].elements['dblPorcentaje'].focus();
	}
	else{		

		document.forms[0].elements['hdnArticuloId'].value = '';				
		document.forms[0].elements['txtArticuloId'].value = '';				
		document.forms[0].elements['txtArticuloDescripcion'].value='';
		document.forms[0].elements['dblPorcentaje'].value = '';		
		document.forms[0].elements['txtArticuloId'].focus();
		
		alert("Articulo no encontrado");
	}
}	 

function dblPorcentaje_onkeydown(objEvent) {
 if (isEnterKey(objEvent)) {    
    document.forms[0].elements['cmdAgregar'].focus();
    return(false);
  }
}

function objPrevioCarga_onclick() {
   
   if (blnEntradaValida()) { 
       var intOpcAct = "";
       if (document.forms[0].elements['optAct1'].checked==true) {
           intOpcAct = "1";    
       }
       if (document.forms[0].elements['optAct2'].checked==true) {
           intOpcAct = "2";    
       }
	   
       var parametrosInicio = '&intPromocionId=' + '<%=Request("intPromocionId")%>' + '&strPromocionNombre=' + '<%=Request("strPromocionNombre")%>' + '&dtmPromocionInicio=' + '<%=Request("dtmPromocionInicio")%>' + '&dtmPromocionFin=' + '<%=Request("dtmPromocionFin")%>';   
	   
       document.forms[0].action = '<%=strFormAction%>?strCmd=PrevioArchivoArticulo&intOpcAct=' + intOpcAct + parametrosInicio; 
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target=''; 
   }   	   
}

function fnVerPrevioCarga (intCargaArchivo, lngFolioActualCarga) {    
   if (intCargaArchivo >= 0) {
   
       document.forms[0].elements['hdnFolioActualCarga'].value = lngFolioActualCarga;
       
       url = 'popVentasPromocionesMonederoVer.aspx?strCmd=VistaPreviaArticulo&lngFolioActualCarga=' + lngFolioActualCarga;      
       var Win = window.open(url,'popPrevioArchivo','width=620,height=540,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );
   }
   else {   
      if (intCargaArchivo==-110) {
	      alert("No se pudo abrir o no existe el archivo de carga");
	  }
	  if (intCargaArchivo==-120) {
	      alert("Los registros del archivo no cumplen con la estructura (articulo y descuento).");
	  }
   }
   
}

function cmdCerrar_onclick() {	
    opener.document.forms[0].elements['cmdEjecutar'].onclick();
	window.close();	
	return(true);
}
function cmdLimpiar_onclick() {
   var parametrosInicio = '?intPromocionId=' + '<%=Request("intPromocionId")%>' + '&strPromocionNombre=' + '<%=Request("strPromocionNombre")%>' + '&dtmPromocionInicio=' + '<%=Request("dtmPromocionInicio")%>' + '&dtmPromocionFin=' + '<%=Request("dtmPromocionFin")%>'; 
   document.forms[0].action = '<%=strFormAction%>' + parametrosInicio;
   document.forms[0].target='';  
   document.forms[0].submit();
}

function cmdAgregar_onclick(blnActualizaPromocion) {
   
   if (blnEntradaValida()) {
   
       var intOpcAct = "";
       
       if (document.forms[0].elements['optAct1'].checked==true) {
           intOpcAct = "1";    
       }
       if (document.forms[0].elements['optAct2'].checked==true) {
           intOpcAct = "2";    
       }
	   
       var parametrosInicio = '&intPromocionId=' + '<%=Request("intPromocionId")%>' + '&strPromocionNombre=' + '<%=Request("strPromocionNombre")%>' + '&dtmPromocionInicio=' + '<%=Request("dtmPromocionInicio")%>' + '&dtmPromocionFin=' + '<%=Request("dtmPromocionFin")%>';   
	   
       document.forms[0].action = '<%=strFormAction%>?strCmd=AgregarArticulo&intOpcAct=' + intOpcAct + '&blnActualizaPromocion=' + blnActualizaPromocion + parametrosInicio;
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target='';      
   }
  
}

function fnUpAgregarArticulo(intActualizacion,strPromociones) {	
    if (intActualizacion > 0 ) {    
	  alert("Promoción actualizada, Total de articulos [" + intActualizacion + "]");       
    }
    else {
	    
		if (intActualizacion==-99) {
           strErrores = 'Confirmar actualización ya que el articulo(s) existe(n) en las promociones:\n' + strPromociones;
		   
		   if (confirm (strErrores) )  {
               cmdAgregar_onclick(1);
		   }
		   
		   return;
		}
				
        if (intActualizacion==-120) {
	      alert("Los registros del archivo no cumplen con la estructura (articulo y descuento).");
		  return;
        }
		
        if (intActualizacion==-110) {
	      alert("No se pudo abrir o no existe el archivo de carga");
		  return;
        }
			
        if (intActualizacion==-100) {
          alert("Error en Bd no se pudo actualizar");
		  return;
		}		
	}
		    
   document.forms[0].elements['hdnFolioActualCarga'].value='';
   document.forms[0].elements['hdnArticuloId'].value = '';		
   document.forms[0].elements['txtArticuloId'].value = '';
   document.forms[0].elements['txtArticuloDescripcion'].value = '';
   document.forms[0].elements['dblPorcentaje'].value='';   
   
   cmdLimpiar_onclick();
       	
}

function fnUpEliminarArticulo(intActualizacion) {
   cmdLimpiar_onclick();
}


function txtArticulosArchivo_onfocus() {
   document.forms[0].elements['optAct2'].checked = true;
   document.forms[0].elements['hdnArticuloId'].value='';
   document.forms[0].elements['txtArticuloId'].value='';
   document.forms[0].elements['txtArticuloDescripcion'].value='';
   document.forms[0].elements['dblPorcentaje'].value='';    
}

function doSubmit()
{

    args = doSubmit.arguments;
    var action = args[0];
	
	if (action == "EliminarArticulo")
	{	
		if  (!confirm ('Esta seguro de eliminar el articulo de la promoción?') )  {
			return;
		}
		else {
             document.forms[0].target="ifrOculto";
		}
	}

	var params = ''
	for (i=1; i < (args.length-1); i +=2) 	{
		params+= '&' + args[i] + '=' + args[i+1]
	}
	
	var parametrosInicio = '&intPromocionId=' + '<%=Request("intPromocionId")%>' + '&strPromocionNombre=' + '<%=Request("strPromocionNombre")%>' + '&dtmPromocionInicio=' + '<%=Request("dtmPromocionInicio")%>' + '&dtmPromocionFin=' + '<%=Request("dtmPromocionFin")%>';
	
	document.forms[0].action = 'popVentasPromocionesMonederoDetalleArticulo.aspx?strCmd=' + action + parametrosInicio +  params;
	document.forms[0].submit(); 
	document.forms[0].target='';	
}

//-->
			</script>
</HEAD>
<body language="javascript" leftMargin="0" topMargin="0" onload="return window_onload()"
		marginwidth="0" marginheight="0">
<form name="frmMonederoDetalleArticulo" method="post" encType="multipart/form-data" runat="server">
  <table height="158" cellSpacing="0" cellPadding="0" width="700" border="0">
    <tr> 
      <td class="tdlogopop" width="100%" colSpan="3" height="21"><IMG height="54" src="../static/images/logo_pop.gif" width="177"></td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td vAlign="top" width="96%" height="10">&nbsp;</td>
      <td width="2%">&nbsp; </td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td vAlign="top" width="96%" height="30"> <h1>Configurar Promoción Monedero 
          por Articulo</h1>
        <p>En esta parte se dan de alta los articulos y el porcentajes que se 
          aplicaran en la promocion.</p></td>
      <td width="2%">&nbsp;</td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td> <table class="tdEnvolventeTablaAzul" cellSpacing="0" cellPadding="0" width="100%" border="0">
          <tr> 
            <td class="tdtexttablebold" vAlign="middle" width="10%">Promoción:</td>
            <td class="tdtextablaBoldAzul" vAlign="middle" width="90%"><%= Request("intPromocionId") %> 
              - <%= Request("strPromocionNombre") %> </td>
          </tr>
          <tr> 
            <td class="tdtexttablebold" vAlign="middle" width="10%">Vigencia:</td>
            <td class="tdtextablaBoldAzul" vAlign="middle" width="90%"><%= Request("dtmPromocionInicio") %> 
              al <%= Request("dtmPromocionFin") %> </td>
          </tr>
        </table>
        <br> <table class="tdEnvolventeTablaGris" width="100%">
          <tr> 
            <td class="tdtexttablebold" width="16%"><input language="javascript" id="optAct1" type="radio" value="1" name="optAct">
              Articulo:</td>
            <td class="tdtexttablebold" width="42%"> <input language="javascript" class="field" id="txtArticuloId" name="txtArticuloId"  onblur="return txtArticuloId_onblur()" onfocus="return txtArticuloId_onfocus()" onkeydown="return txtArticuloId_onkeydown(event)" type="text" maxLength="13" size="8"  autocomplete="off" value='<%=Request("txtArticuloId")%>'> 
              &nbsp; <a id="objLupaArticulo"><IMG height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0"></a><span class="txconttablasrojo"> 
              <input language="javascript" class="campotablaresultado" id="txtArticuloDescripcion" name="txtArticuloDescripcion" size="28" readOnly border="0" value='<%=Request.Form("txtArticuloDescripcion")%>' >
              </span> </td>
            <td class="tdtexttablebold" width="12%">Porcentaje:</td>
            <td width="4%" class="tdtexttablebold"> <input class="field" id="dblPorcentaje" name="dblPorcentaje" value='<%=Request("dblPorcentaje")%>' type="text" maxLength="2" size="2"  autocomplete="off" onkeydown="return dblPorcentaje_onkeydown(event)"></td>
            <td align="center" width="26%" rowspan="2"> <input class="button" id="cmdAgregar" name="cmdAgregar" value="Agregar" onclick="return cmdAgregar_onclick(0)"
										type="button"> <input class="button" id="cmdLimpiar" name="cmdLimpiar" value="Limpiar" onclick="return cmdLimpiar_onclick()"
										type="button"> </td>
          </tr>
          <tr> 
            <td width="16%" class="tdtexttablebold"><input language="javascript" id="optAct2" type="radio" value="2" name="optAct">
              Archivo:</td>
            <td width="58%" class="tdtexttablebold" colSpan="3"><input language="javascript" class="tdcontentableblue" id="txtArticulosArchivo" title="Archivo"
										onfocus="return txtArticulosArchivo_onfocus()" type="file" size="30" name="txtArticulosArchivo" runat="server"> 
              &nbsp; <a id="objPrevioCarga" onclick="objPrevioCarga_onclick()"><IMG height="17" src="../static/images/imgNRPrevio.gif" width="17" align="absMiddle"
											border="0"></a> </td>
          </tr>
        </table>
        <table width="100%">
          <tr> 
            <td><input class="boton" id="cmdCerrar" onclick="return cmdCerrar_onclick()" type="button"
										value="Cerrar" name="cmdCerrar"> </td>
          </tr>
          <tr> 
            <td><span class="txsubtitulo"><br>
              <IMG height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Detalle 
              Promoción</span><%=strConsultarDetalle%><br> </td>
          </tr>
        </table></td>
      <td width="2%">&nbsp;</td>
    </tr>
    <tr> 
      <input type="hidden" name="hdnFolioActualCarga"  value='<%=Request("hdnFolioActualCarga")%>' >
      <input type='hidden' name='hdnArticuloId' value= '<%=Request("hdnArticuloId")%>'>
    </tr>
  </table>
</form>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
</body>
</HTML>

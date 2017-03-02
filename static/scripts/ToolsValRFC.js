// Estas constantes ya estan en Tools.js  Por eso aqui comentarizadas
//var cblnMostrarShowModalDialog	=false; //false muestra mensajes en Alerts
//var cstrAtributosVentana		="dialogWidth:305px;dialogHeight:145px;dialogTop:225px;dialogLeft:250px;status:no;help:no;"

var cintTipoCampoRFC			=1000;

function MostrarMensajeRFC(objCampo,strEtiquetaCampo,intTipoCampo,intNoMensaje,intLength,strCaracterNoValido) 
{
	strMsgShowModal="";
	strMsgAlert="";
	//- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
	if(intTipoCampo==cintTipoCampoRFC){
		if(intNoMensaje==1001){ // Len=12 PRIMERO VALIDAMOS QUE LAS INICIALES NO TENGAN ALGUN NUMERO
			strMsgShowModal	="EL RFC proporcionado esta incorrecto.";
			strMsgAlert		="EL RFC proporcionado "+ "en el campo \"" + strEtiquetaCampo +"\", esta incorrecto.";
		}
		if(intNoMensaje==1002){ // Len=12 CHECAMOS SI LA FECHA ES VALIDA
			strMsgShowModal	="EL RFC proporcionado esta incorrecto.";
			strMsgAlert		="EL RFC proporcionado "+ "en el campo \"" + strEtiquetaCampo +"\", esta incorrecto.";
		}
		if(intNoMensaje==1003){ // Len=13 PRIMERO VALIDAMOS QUE LAS INICIALES NO TENGAN ALGUN NUMERO
			strMsgShowModal	="EL RFC proporcionado esta incorrecto.";
			strMsgAlert		="EL RFC proporcionado "+ "en el campo \"" + strEtiquetaCampo +"\", esta incorrecto.";
		}
		if(intNoMensaje==1004){ // Len=13 CHECAMOS SI LA FECHA ES VALIDA
			strMsgShowModal	="EL RFC proporcionado esta incorrecto.";
			strMsgAlert		="EL RFC proporcionado "+ "en el campo \"" + strEtiquetaCampo +"\", esta incorrecto.";
		}
		if(intNoMensaje==1005){ // Len=9 PRIMERO VALIDAMOS QUE LAS INICIALES NO TENGAN ALGUN NUMERO
			strMsgShowModal	="EL RFC proporcionado esta incorrecto.";
			strMsgAlert		="EL RFC proporcionado "+ "en el campo \"" + strEtiquetaCampo +"\", esta incorrecto.";
		}
		if(intNoMensaje==1006){ // Len=9 CHECAMOS SI LA FECHA ES VALIDA
			strMsgShowModal	="EL RFC proporcionado esta incorrecto.";
			strMsgAlert		="EL RFC proporcionado "+ "en el campo \"" + strEtiquetaCampo +"\", esta incorrecto.";
		}
		if(intNoMensaje==1007){ // Len=10 VALIDAMOS QUE LAS INICIALES NO TENGAN ALGUN NUMERO
			strMsgShowModal	="EL RFC proporcionado esta incorrecto.";
			strMsgAlert		="EL RFC proporcionado "+ "en el campo \"" + strEtiquetaCampo +"\", esta incorrecto.";
		}
		if(intNoMensaje==1008){ // Len=10 CHECAMOS SI LA FECHA ES VALIDA
			strMsgShowModal	="EL RFC proporcionado esta incorrecto.";
			strMsgAlert		="EL RFC proporcionado "+ "en el campo \"" + strEtiquetaCampo +"\", esta incorrecto.";
		}
		if(intNoMensaje==1009){ // Len= NINGUNA LONGITUD
			strMsgShowModal	="EL RFC proporcionado esta incorrecto.";
			strMsgAlert		="EL RFC proporcionado "+ "en el campo \"" + strEtiquetaCampo +"\", esta incorrecto.";
		}
	}

	if(cblnMostrarShowModalDialog) {
		window.showModalDialog("vShowModal.asp?msg="+strMsgShowModal+"&campo="+strEtiquetaCampo,"",cstrAtributosVentana);
	}
	else {
		alert(strMsgAlert);
	}
	if(objCampo.disabled==false){ objCampo.focus(); }
}	
	//- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

/////////////////////////////////////////////////////////////////////////////////////
function blnValidarRFC(objCampoRFC,strEtiquetaCampo,blnRequerido){
		var strRFC;
		strRFC = objCampoRFC.value;
		var iniciales;
		var fecha;
		var homoclave;
		
		if(blnRequerido==false && strRFC==""){	// No es requerdio y no escribio nada; No hay necesidad
			return(true);						// de continuar con la validación
		}
		
		if(strRFC.length==12){			
			iniciales=strRFC.substring(0,3);
			fecha=strRFC.substring(3,9);
			homoclave=strRFC.substring(9,12);
			
			// PRIMERO VALIDAMOS QUE LAS INICIALES NO TENGAN ALGUN NUMERO
			for (i=0; i < 3; i=i+1){
				if	(isNaN(strRFC.charAt(i))){
					}
				else {
					MostrarMensajeRFC(objCampoRFC,strEtiquetaCampo,cintTipoCampoRFC,1001)
					return(false);
					break;
					}
				}
			
			// CHECAMOS SI LA FECHA ES VALIDA
				var anio=fecha.substring(0,2);
				var mes=fecha.substring(2,4);
				var dia=fecha.substring(4,6);
						
				var formatfecha=mes + "/" +  dia + "/" + "20" + anio
				if (!isDate(formatfecha)){
					MostrarMensajeRFC(objCampoRFC,strEtiquetaCampo,cintTipoCampoRFC,1002)
					return(false);
				}
		}
		else{
			if(strRFC.length==13){
					iniciales=strRFC.substring(0,4);
					fecha=strRFC.substring(4,10);
					homoclave=strRFC.substring(10,13);
					// PRIMERO VALIDAMOS QUE LAS INICIALES NO TENGAN ALGUN NUMERO
					for (i=0; i < 4; i=i+1){
						if	(isNaN(iniciales.charAt(i))){
							}
						else {
							MostrarMensajeRFC(objCampoRFC,strEtiquetaCampo,cintTipoCampoRFC,1003)
							return(false);
							break;
							}
								
						}
					// CHECAMOS SI LA FECHA ES VALIDA
					var anio=fecha.substring(0,2);
					var mes=fecha.substring(2,4);
					var dia=fecha.substring(4,6);
						
					var formatfecha=mes + "/" +  dia + "/" + "20" + anio
						
					if (!isDate(formatfecha)){
						MostrarMensajeRFC(objCampoRFC,strEtiquetaCampo,cintTipoCampoRFC,1004)
						return(false);
					}
			}
			else{
					// =======================================================
					if(strRFC.length==9){			
						//Valida persona moral xxxaammddxxx sin homoclave
						//alert("primeraparte: " + strRFC.substring(0,3))
						iniciales=strRFC.substring(0,3);
						fecha=strRFC.substring(3,9);						
							
						// PRIMERO VALIDAMOS QUE LAS INICIALES NO TENGAN ALGUN NUMERO
						for (i=0; i < 3; i=i+1){
							if	(isNaN(strRFC.charAt(i))){
								}
							else {
								MostrarMensajeRFC(objCampoRFC,strEtiquetaCampo,cintTipoCampoRFC,1005)
								return(false);
								break;
								}
							}
							
						// CHECAMOS SI LA FECHA ES VALIDA
							var anio=fecha.substring(0,2);
							var mes=fecha.substring(2,4);
							var dia=fecha.substring(4,6);
										
							var formatfecha=mes + "/" +  dia + "/" + "20" + anio
							if (!isDate(formatfecha)){
								MostrarMensajeRFC(objCampoRFC,strEtiquetaCampo,cintTipoCampoRFC,1006)
								return(false);
							}
					}
					else{
							if(strRFC.length==10){
									//Valida persona fisica xxxxaammddxxx sin homoclave
									iniciales=strRFC.substring(0,4);
									fecha=strRFC.substring(4,10);									
									
									// PRIMERO VALIDAMOS QUE LAS INICIALES NO TENGAN ALGUN NUMERO
									for (i=0; i < 4; i=i+1){
										if	(isNaN(iniciales.charAt(i))){
											}
										else {
											MostrarMensajeRFC(objCampoRFC,strEtiquetaCampo,cintTipoCampoRFC,1007)
											return(false);
											break;
											}
												
										}
									// CHECAMOS SI LA FECHA ES VALIDA
									var anio=fecha.substring(0,2);
									var mes=fecha.substring(2,4);
									var dia=fecha.substring(4,6);
										
									var formatfecha=mes + "/" +  dia + "/" + "20" + anio
										
									if (!isDate(formatfecha)){
										MostrarMensajeRFC(objCampoRFC,strEtiquetaCampo,cintTipoCampoRFC,1008)
										return(false);
									}
							}
							else{
								MostrarMensajeRFC(objCampoRFC,strEtiquetaCampo,cintTipoCampoRFC,1009)
								return(false);
							}	
					}
					// =======================================================
			}	
		}
		return(true);
	}
/////////////////////////////////////////////////////////////////////////////////////	
	
/******************************************************
Verifica que "dtmDate" sea una representación válida de
una fecha en el formato MM/dd/yyyy.   Esta funcion se emplea en: function blnValidarRFC(objCampoRFC,strEtiquetaCampo)
*******************************************************/
function isDate(dtmDate){
  var dd,mm,yy,idd,imm,iyy,sf,format;
  var dias = new Array(31,28,31,30,31,30,31,31,30,31,30,31);
  sf = dtmDate
  
  if(sf.length > 10) 
  {
  return false;
  }
  
  mm= sf.substring(0,sf.indexOf("/"));
  if(mm.length > 2) 
  {
  return false;
  }
   
   dd= sf.substring(sf.indexOf("/")+1,sf.lastIndexOf("/"));
  if(dd.length > 2) 
  {
  return false;
  } 
  
  yy = sf.substring(sf.lastIndexOf("/")+1,sf.length);
  if(yy.length != 4) 
  {
  return false;
  } 
  
  idd = parseInt(dd,10);
  imm = parseInt(mm,10);
  iyy = parseInt(yy,10);

  if(isNaN(idd) || isNaN(imm) || isNaN(iyy)) return false;
  if((iyy % 40) == 0)
     dias[1] = 29;
  else
    if((iyy % 4 == 0) && (iyy % 100 != 0)) dias[1] = 29;

  if(imm < 1 || imm > 12) return false;

  if(idd < 1 || idd > dias[imm-1]) return false;
  return true;
}	
/////////////////////////////////////////////////////////////////////////////////////	  
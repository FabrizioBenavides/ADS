// Title: Tigra Menu GOLD
// URL: http://www.softcomplex.com/products/tigra_menu_gold/
// Version: 2.5
// Date: 11-20-2003 (mm-dd-yyyy)
// Technical Support: support@softcomplex.com (specify product title and order ID)
// Notes: Registration needed to use this script legally.
// Visit official site for details.

document.write('<style>.mlyri{position:absolute;left:0;top:0}.mlyrh{width:1;height:1;position:absolute;left:0;top:0;visibility:hidden}</style>');function TM0(){this.TM1=navigator.userAgent.indexOf('MSIE')>-1;this.TM2=navigator.userAgent.indexOf('MSIE 6')>-1;this.TM3=document.all?function(i){return document.all[i]}:function(i){return document.getElementById(i)};this.TM4=function(n,TM5,TM6){var TM7={'x':TM5,'y':TM6};for(;n;n=n.offsetParent){TM7.x+=n.offsetLeft;TM7.y+=n.offsetTop}return TM7};this.TM8=function(TM9,TMA){TM9.style.visibility=TMA?'visible':'hidden'};this.TMB=function(TM9,TMC){TM9.style.left=TMC.x+'px';TM9.style.top=TMC.y+'px'};this.TMD=function(TM9,TME){return TM9[TME?'offsetHeight':'offsetWidth']};this.TMF=top.document.body}function TMG(TMH){var TMI=false;for(var i in menus)if(menus[i].TMJ!=null)TMI=true;if(TMI&&TMH)return;for(i in this.TMK)if(document.forms[i]){var TML=document.forms[i];for(var j=0;j<TML.elements.length;j++){var TMM=TML.elements[j];if(TMM.type.indexOf('select-')>-1)TMM.style.visibility=TMM.style.overflow=TMH?'visible':'hidden'}}}function TMN(TMO){var TMP=this.TMQ+(this.TMR+1)*3,TMS=this.TMT[0],TMU=TMS.TMV('table'),TMW=['<table cellpadding="',TMU[0],'" cellspacing="',TMU[1],'" border="',TMU[2],'" class="',TMS.TMX('table'),'"><tr>',this.TMY.join(''),'</tr></table>'].join('');if(TMO){var TMZ=TMS.TMV('block_top'),TMa=TMS.TMV('block_left'),TMb='';if(TMZ!=null||TMa!=null)TMb=';top:'+TMZ+';left:'+TMa;if(top!=window&&!this.TMc||this.TMd)TMb+=';visibility:hidden';document.write('<div',TMb?' style="z-index:'+TMP+TMb+'" class=mlyri':'',' id="m',this.id,'c">',TMW,'</div>');this.TMe=this.TMf=TMg.TM3('m'+this.TMh.id+'c')}else{this.TMf=document.createElement('div');document.body.appendChild(this.TMf);this.TMf.className='mlyrh';this.TMf.style.zIndex=0;this.TMf.innerHTML=TMW}if(document.body.style.filter!=null){var filter='';if(t=this.TMi.be||TMS.TMV('transition')){if(this.TMj=t[0]!=null)filter+=t[0];if(t[1]!=null){filter+=' '+t[1];this.TMk=this.TMj?1:0}}if(TMl=TMS.TMV('shadow'))filter+=' progid:DXImageTransform.Microsoft.Shadow(strength=3,direction='+Math.atan2(TMl.offY,-TMl.offX)/Math.PI*180+',color='+TMl.color+')';if(TMm=TMS.TMV('opacity'))filter+=' alpha(opacity='+TMm+')';this.TMf.style.filter=filter}if(TMg.TM2&&(!TMO||TMb)){document.body.insertAdjacentHTML("afterBegin",['<iframe style="position:absolute;filter:alpha(opacity=0);z-index:',TMP-1,';width:',this.TMf.offsetWidth+(TMS.TMl?TMS.TMl.offX:0),';height:',this.TMf.offsetHeight+(TMS.TMl?TMS.TMl.offY:0),'" id="m',this.TMh.id,'if',this.id,'" src="',TMg.TMn,'"></iframe>'].join(''));this.TMo=document.getElementById('m'+this.TMh.id+'if'+this.id)}}function TMp(w,h){return['<td><div style="position:relative;margin:0;width:',w,';height:',h,'"><div class=mlyri><table cellpadding="0" cellspacing="0" border="0" width="',w,'" height="',h,'" class="',this.TMX('outer',0),'" id="m',this.TMh.id,'tb',this.id,'"><tr><td class="',this.TMX('inner',0),'" id="m',this.TMh.id,'td',this.id,'">',typeof(this.TMq[0])=='object'?this.TMq[0][0]:this.TMq[0],'</td></tr></table></div><div class=mlyrh id="m',this.TMh.id,'i',this.id,'"><table cellpadding="0" cellspacing="0" border="0" width="',w,'" height="',h,'" class="',this.TMX('outer',1),'"><tr><td class="',this.TMX('inner',1),'">',typeof(this.TMq[0])=='object'?this.TMq[0][1]:this.TMq[0],'</td></tr></table></div><div class=mlyri><a href="',this.TMq[1]?this.TMq[1]:'javascript:','"',this.TMi.tw?' target="'+this.TMi.tw+'"':'',' onclick="return menus[\'',this.TMh.id,'\'].exec(\'',this.id,'\',0)" onmouseout="menus[\'',this.TMh.id,'\'].exec(\'',this.id,'\',1)" onmouseover="menus[\'',this.TMh.id,'\'].exec(\'',this.id,'\',2)" onmousedown="menus[\'',this.TMh.id,'\'].exec(\'',this.id,'\',3)"><img src="',TMg.TMn,'" width="',w,'" height="',h,'" border="0"',this.TMi.tt?' alt="'+this.TMi.tt+'"':'','></a></div></div></td>',this.TMr[this.TMR]!=this.TMs.TMt-1&&this.TMs.TMT[0].TMu?'</tr><tr>':''].join('')}function TMv(){this.elements=[TMg.TM3(['m',this.TMh.id,'td',this.id].join('')),TMg.TM3(['m',this.TMh.id,'tb',this.id].join('')),TMg.TM3(['m',this.TMh.id,'i',this.id].join(''))]}function TMw(TMx){if(TMx==this.TMx)return;if(this.TMx==1)this.elements[2].style.visibility='hidden';else if(this.TMx==2){if(typeof(this.TMq[0])=='object')this.elements[0].innerHTML=this.TMq[0][0];this.elements[1].className=this.TMX('outer',0);this.elements[0].className=this.TMX('inner',0)}if(TMx==1)this.elements[2].style.visibility='visible';else if(TMx==2){if(typeof(this.TMq[0])=='object')this.elements[0].innerHTML=this.TMq[0][2];this.elements[1].className=this.TMX('outer',2);this.elements[0].className=this.TMX('inner',2)}this.TMx=TMx}function TMy(TMz){if(this.TMf){for(var i in this.TMT)this.TMT[i].TM00(0);if(this.TMo)TMg.TM8(this.TMo);if(this.TMh.TM01)this.TMh.TM01.stop();if(this.TMk!=null)try{this.TMh.TM01=this.TMf.filters[this.TMk];this.TMf.filters[this.TMk].apply()}catch(e){};TMg.TM8(this.TMf);if(this.TMk!=null)try{this.TMf.filters[this.TMk].play()}catch(e){}}if(TMz>=this.TMR){if(this!=this.TMh.TM02&&this.TM00)this.TM00(0)}else this.TMs.TM03(TMz)}function TM04(){if(this.TMh.TMJ&&this.TMR<=this.TMh.TMJ.TMR)this.TMh.TMJ.TM03((this.TMh.TMJ.TMs==this)*1+this.TMR);this.TMh.TMJ=this;if(this.TMt>0){if(this.TMh.TM01)try{this.TMh.TM01.stop()}catch(e){};if(!this.TMf&&this.TMt>0)this.TM05();this.TM06();if(this.TMj)try{this.TMh.TM01=this.TMf.filters[0];this.TMf.filters[0].apply()}catch(e){};if(!TMg.TM2)this.TMh.TM07();TMg.TM8(this.TMf,true);if(this.TMj)try{this.TMf.filters[0].play()}catch(e){};if(this.TMo)TMg.TM8(this.TMo,true)}}
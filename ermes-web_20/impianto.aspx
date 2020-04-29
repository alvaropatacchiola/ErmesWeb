<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/main.Master" CodeBehind="impianto.aspx.vb" Inherits="ermes_web_20.impianto" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ MasterType VirtualPath="~/main.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    <meta http-equiv='refresh' content='600'/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
			
<asp:Label ID="Label2" runat="server" Text="<h3 class='heading-mosaic'>Overview</h3>" meta:resourcekey="Label2Resource1"></asp:Label>
 <!--- MENU -->
 	
    <!---
 		<div class="tabsbar">
			<ul>
				<li class="active"><a href="#tab1-3" data-toggle="tab"> Piscina piccola <strong>(4)</strong></a></li>
				<li><a href="#tab2-3" data-toggle="tab"> Piscina grande <strong>(2)</strong></a></li>
				<li><a href="#tab3-3" data-toggle="tab"> <span>Spa <strong>(1)</strong></span></a></li>
           
		  </ul>
		</div>
        -->
                <asp:Label ID="Label1" runat="server" Text="Label" meta:resourcekey="Label1Resource1"></asp:Label>
  <!--- MENU -->
<asp:Label ID="Label3" runat="server" Text="Label" meta:resourcekey="Label3Resource1"></asp:Label>

  
  
  
  
  
  
  
  

        
        
		<div class="clearfix"></div>
        
        </div>
        
        

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="script_at_end" runat="server">


     <script>
         function crea_mappa() {
             var geocoder;
             var map;
             geocoder = new google.maps.Geocoder();
             var latlng = new google.maps.LatLng(-34.397, 150.644);
             var mapOptions = {
                 zoom: 10,
                 center: latlng,
                 mapTypeId: google.maps.MapTypeId.ROADMAP
             }
             map = new google.maps.Map(document.getElementById('pippo'), mapOptions);
             geocoder.geocode({ 'address': indirizzo }, function (results, status) {
                 if (status == google.maps.GeocoderStatus.OK) {
                     map.setCenter(results[0].geometry.location);
                     var marker = new google.maps.Marker({
                         map: map,
                         position: results[0].geometry.location
                     });
                 } else {
                     alert('Geocode was not successful for the following reason: ' + status);
                 }
             });
             google.maps.event.addDomListener(window, 'load', initialize);
             google.maps.event.trigger(map, 'resize')
         }
         
         $('a[href="#quickPhotosTab"]').on('shown', function (e) {
             //google.maps.event.trigger(map, 'resize');

             if (indirizzo != '') {
                 
                 crea_mappa();
             }

         });
         </script>
    
   
    </asp:Content>


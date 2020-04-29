<%@ Page Title="" Language="vb" EnableEventValidation="false" AutoEventWireup="true" MasterPageFile="~/main.Master" CodeBehind="addimpianto.aspx.vb" Inherits="ermes_web_20.addimpianto" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ MasterType VirtualPath="~/main.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="theme/css/custom.css" rel="stylesheet" />
    <!--<script src="theme/scripts/demo/common.js?1366720739"></script>-->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script_footer" runat="server">
    <!-- Bootstrap Form Wizard Plugin -->
    <script src="bootstrap/extend/twitter-bootstrap-wizard/jquery.bootstrap.wizard.js"></script>
    <!-- Form Wizards Page Demo Script -->
    <script src="theme/scripts/demo/form_wizards.js"></script>
    <script src="theme/scripts/demo/notifications.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div id="principale_alert" style="z-index:10000; position:absolute" >
    </div>

    <div id="content">


<h3 class="heading-mosaic"><asp:Literal ID="Literal1" runat="server" Text="Aggiungi un impianto." meta:resourcekey="Literal1Resource1"></asp:Literal></h3>
       
        <div class="innerLR">
        
        	<!-- Form Wizard / Arrow navigation & Progress bar -->
	<div  class="wizard">
	<div class="widget widget-tabs widget-tabs-double">
		<!-- Wizard heading -->
		<div class="widget-head">
			<ul>
				
				<li class="active"><a id ="tab1_1"class="glyphicons pencil" href="#tab1" data-toggle="tab"><i></i><span class="strong"><asp:Literal ID="Literal5_1" runat="server" Text="Step 1" meta:resourcekey="Literal5_1Resource1"></asp:Literal></span><span><asp:Literal ID="Literal5" runat="server" Text="Sito Impianto" meta:resourcekey="Literal5Resource1"></asp:Literal></span></a></li>
                <li><a id ="tab2_2" href="#tab2" class="glyphicons pencil" data-toggle="tab"><i></i><span class="strong"><asp:Literal ID="Literal6_1" runat="server" Text="Step 2" meta:resourcekey="Literal6_1Resource1"></asp:Literal></span><span><asp:Literal ID="Literal6" runat="server" Text="Impianto" meta:resourcekey="Literal6Resource1"></asp:Literal></span></a></li>
                <li><a id ="tab3_3" href="#tab3" class="glyphicons pencil" data-toggle="tab"><i></i><span class="strong"><asp:Literal ID="Literal2_1" runat="server" Text="Step 3" meta:resourcekey="Literal2_1Resource1"></asp:Literal></span><span><asp:Literal ID="Literal2" runat="server" Text="Codice Impianto" meta:resourcekey="Literal2Resource1"></asp:Literal></span></a></li>
				<li><a id ="tab4_4" href="#tab4" class="glyphicons pencil" data-toggle="tab"><i></i><span class="strong"><asp:Literal ID="Literal3_1" runat="server" Text="Step 4" meta:resourcekey="Literal3_1Resource1"></asp:Literal></span><span><asp:Literal ID="Literal3" runat="server" Text="Indirizzo" meta:resourcekey="Literal3Resource1"></asp:Literal></span></a></li>
				<li><a id ="tab5_5" href="#tab5" class="glyphicons pencil" data-toggle="tab"><i></i><span class="strong"><asp:Literal ID="Literal4_1" runat="server" Text="Step 5" meta:resourcekey="Literal4_1Resource1"></asp:Literal></span><span><asp:Literal ID="Literal4" runat="server" Text="Referente" meta:resourcekey="Literal4Resource1"></asp:Literal></span></a></li>
                <li><a id ="tab6_6" href="#tab6" class="glyphicons pencil" data-toggle="tab"><i></i><span class="strong"><asp:Literal ID="Literal9_1" runat="server" Text="Step 3" meta:resourcekey="Literal9_1Resource1"></asp:Literal></span><span><asp:Literal ID="Literal9" runat="server" Text="Utilizzatore" meta:resourcekey="Literal9Resource1"></asp:Literal></span></a></li>
			</ul>
		</div>
		<!-- // Wizard heading END -->
		
		<div class="widget-body">
		
			<!-- Wizard Progress bar 
			<div class="widget-head progress progress-primary" id="bar">
				<div class="bar">Step <strong class="step-current">1</strong> of <strong class="steps-total">6</strong> - <strong class="steps-percent">100%</strong></div>
			</div>
                -->
			<!-- // Wizard Progress bar END -->
			
			<div class="widget-body">
				<div class="tab-content">
				
					<!-- Step 1 -->
					<div class="tab-pane" id="tab3">
						<div class="row-fluid">
							<div class="span3">
								<strong><asp:Literal ID="Literal7" runat="server" Text="Dati impianto" meta:resourcekey="Literal7Resource1"></asp:Literal> </strong>
								<p class="muted"><asp:Literal ID="Literal8" runat="server" Text="Inserisci i dati relativi al nuovo impianto" meta:resourcekey="Literal8Resource1"></asp:Literal></p>
							</div>
							<div class="span9">
								<div class="separator"></div>
                                <p><asp:Literal ID="Literal10" runat="server" Text="Codice" meta:resourcekey="Literal10Resource1"></asp:Literal></p>
                                <asp:TextBox  ID="inputCodice" onblur="javascript: Changed_channel( 'inputCodice',6);" class="span6"  runat="server" MaxLength="17" meta:resourcekey="inputCodiceResource1" ClientIDMode="Static"></asp:TextBox>
                                								
                                <div class="separator"></div>
                             	<p><asp:Literal ID="Literal11" runat="server" Text="Descrizione" meta:resourcekey="Literal11Resource1"></asp:Literal></p>
                                <asp:TextBox ClientIDMode="Static" ID="textDescription"  style="width: 96%;" rows="5"   runat="server" TextMode="MultiLine" meta:resourcekey="textDescriptionResource1"></asp:TextBox>
                                
							</div>
						</div>
					</div>
					<!-- // Step 1 END -->
					
					<!-- Step 2 -->
					<div class="tab-pane" id="tab4">
						<div class="row-fluid">
							<div class="span3">
								<strong><asp:Literal ID="Literal12" runat="server" Text="Indirizzo impianto" meta:resourcekey="Literal12Resource1"></asp:Literal></strong>
								<p class="muted"><asp:Literal ID="Literal13" runat="server" Text="Inserisci un indirizzo valido" meta:resourcekey="Literal13Resource1"></asp:Literal></p>
							</div>
							<div class="span9">
                            
                            	<p><asp:Literal ID="Literal14" runat="server" Text="Seleziona un indirizzo già esistente" meta:resourcekey="Literal14Resource1"></asp:Literal></p>
								<asp:DropDownList ClientIDMode="Static" ID="indirizzi" runat="server" meta:resourcekey="indirizziResource1">
                                    <asp:ListItem Value="nuovo" meta:resourcekey="ListItemResource1">Nuovo..</asp:ListItem>
								</asp:DropDownList>

                                    <!--
                                    <asp:ListItem Value="IT-Italy-Roma-Roma-via arice, 1">Italy - Roma - Roma- via arice, 1</asp:ListItem>
                                    <asp:ListItem Value="IT-Italy-Roma--via arice, ">Italy - Roma - via arice </asp:ListItem>
                                     -->
								
                                <div class="separator"></div>
                                <p><asp:Literal ID="Literal15" runat="server" Text="Oppure inserisci un nuovo indirizzo" meta:resourcekey="Literal15Resource1"></asp:Literal></p>
                                
                                <div class="separator"></div>
                                <p><asp:Literal ID="Literal16" runat="server" Text="Nazione" meta:resourcekey="Literal16Resource1"></asp:Literal></p>
							
								
                                    <asp:DropDownList ClientIDMode="Static" ID="countries" runat="server" meta:resourcekey="countriesResource1">
<asp:ListItem value="empty">Empty</asp:ListItem>
<asp:ListItem value="AF" meta:resourcekey="ListItemResource2">Afghanistan</asp:ListItem>
<asp:ListItem value="AX" meta:resourcekey="ListItemResource3">Åland Islands</asp:ListItem>
<asp:ListItem value="AL" meta:resourcekey="ListItemResource4">Albania</asp:ListItem>
<asp:ListItem value="DZ" meta:resourcekey="ListItemResource5">Algeria</asp:ListItem>
<asp:ListItem value="AS" meta:resourcekey="ListItemResource6">American Samoa</asp:ListItem>
<asp:ListItem value="AD" meta:resourcekey="ListItemResource7">Andorra</asp:ListItem>
<asp:ListItem value="AO" meta:resourcekey="ListItemResource8">Angola</asp:ListItem>
<asp:ListItem value="AI" meta:resourcekey="ListItemResource9">Anguilla</asp:ListItem>
<asp:ListItem value="AQ" meta:resourcekey="ListItemResource10">Antarctica</asp:ListItem>
<asp:ListItem value="AG" meta:resourcekey="ListItemResource11">Antigua and Barbuda</asp:ListItem>
<asp:ListItem value="AR" meta:resourcekey="ListItemResource12">Argentina</asp:ListItem>
<asp:ListItem value="AM" meta:resourcekey="ListItemResource13">Armenia</asp:ListItem>
<asp:ListItem value="AW" meta:resourcekey="ListItemResource14">Aruba</asp:ListItem>
<asp:ListItem value="AU" meta:resourcekey="ListItemResource15">Australia</asp:ListItem>
<asp:ListItem value="AT" meta:resourcekey="ListItemResource16">Austria</asp:ListItem>
<asp:ListItem value="AZ" meta:resourcekey="ListItemResource17">Azerbaijan</asp:ListItem>
<asp:ListItem value="BS" meta:resourcekey="ListItemResource18">Bahamas</asp:ListItem>
<asp:ListItem value="BH" meta:resourcekey="ListItemResource19">Bahrain</asp:ListItem>
<asp:ListItem value="BD" meta:resourcekey="ListItemResource20">Bangladesh</asp:ListItem>
<asp:ListItem value="BB" meta:resourcekey="ListItemResource21">Barbados</asp:ListItem>
<asp:ListItem value="BY" meta:resourcekey="ListItemResource22">Belarus</asp:ListItem>
<asp:ListItem value="BE" meta:resourcekey="ListItemResource23">Belgium</asp:ListItem>
<asp:ListItem value="BZ" meta:resourcekey="ListItemResource24">Belize</asp:ListItem>
<asp:ListItem value="BJ" meta:resourcekey="ListItemResource25">Benin</asp:ListItem>
<asp:ListItem value="BM" meta:resourcekey="ListItemResource26">Bermuda</asp:ListItem>
<asp:ListItem value="BT" meta:resourcekey="ListItemResource27">Bhutan</asp:ListItem>
<asp:ListItem value="BO" meta:resourcekey="ListItemResource28">Bolivia</asp:ListItem>
<asp:ListItem value="BA" meta:resourcekey="ListItemResource29">Bosnia and Herzegovina</asp:ListItem>
<asp:ListItem value="BW" meta:resourcekey="ListItemResource30">Botswana</asp:ListItem>
<asp:ListItem value="BV" meta:resourcekey="ListItemResource31">Bouvet Island</asp:ListItem>
<asp:ListItem value="BR" meta:resourcekey="ListItemResource32">Brazil</asp:ListItem>
<asp:ListItem value="IO" meta:resourcekey="ListItemResource33">British Indian Ocean Territory</asp:ListItem>
<asp:ListItem value="BN" meta:resourcekey="ListItemResource34">Brunei Darussalam</asp:ListItem>
<asp:ListItem value="BG" meta:resourcekey="ListItemResource35">Bulgaria</asp:ListItem>
<asp:ListItem value="BF" meta:resourcekey="ListItemResource36">Burkina Faso</asp:ListItem>
<asp:ListItem value="BI" meta:resourcekey="ListItemResource37">Burundi</asp:ListItem>
<asp:ListItem value="KH" meta:resourcekey="ListItemResource38">Cambodia</asp:ListItem>
<asp:ListItem value="CM" meta:resourcekey="ListItemResource39">Cameroon</asp:ListItem>
<asp:ListItem value="CA" meta:resourcekey="ListItemResource40">Canada</asp:ListItem>
<asp:ListItem value="CV" meta:resourcekey="ListItemResource41">Cape Verde</asp:ListItem>
<asp:ListItem value="KY" meta:resourcekey="ListItemResource42">Cayman Islands</asp:ListItem>
<asp:ListItem value="CF" meta:resourcekey="ListItemResource43">Central African Republic</asp:ListItem>
<asp:ListItem value="TD" meta:resourcekey="ListItemResource44">Chad</asp:ListItem>
<asp:ListItem value="CL" meta:resourcekey="ListItemResource45">Chile</asp:ListItem>
<asp:ListItem value="CN" meta:resourcekey="ListItemResource46">China</asp:ListItem>
<asp:ListItem value="CX" meta:resourcekey="ListItemResource47">Christmas Island</asp:ListItem>
<asp:ListItem value="CC" meta:resourcekey="ListItemResource48">Cocos (Keeling) Islands</asp:ListItem>
<asp:ListItem value="CO" meta:resourcekey="ListItemResource49">Colombia</asp:ListItem>
<asp:ListItem value="KM" meta:resourcekey="ListItemResource50">Comoros</asp:ListItem>
<asp:ListItem value="CG" meta:resourcekey="ListItemResource51">Congo</asp:ListItem>
<asp:ListItem value="CD" meta:resourcekey="ListItemResource52">Congo, The Democratic Republic of The</asp:ListItem>
<asp:ListItem value="CK" meta:resourcekey="ListItemResource53">Cook Islands</asp:ListItem>
<asp:ListItem value="CR" meta:resourcekey="ListItemResource54">Costa Rica</asp:ListItem>
<asp:ListItem value="CI" meta:resourcekey="ListItemResource55">Cote D'ivoire</asp:ListItem>
<asp:ListItem value="HR" meta:resourcekey="ListItemResource56">Croatia</asp:ListItem>
<asp:ListItem value="CU" meta:resourcekey="ListItemResource57">Cuba</asp:ListItem>
<asp:ListItem value="CY" meta:resourcekey="ListItemResource58">Cyprus</asp:ListItem>
<asp:ListItem value="CZ" meta:resourcekey="ListItemResource59">Czech Republic</asp:ListItem>
<asp:ListItem value="DK" meta:resourcekey="ListItemResource60">Denmark</asp:ListItem>
<asp:ListItem value="DJ" meta:resourcekey="ListItemResource61">Djibouti</asp:ListItem>
<asp:ListItem value="DM" meta:resourcekey="ListItemResource62">Dominica</asp:ListItem>
<asp:ListItem value="DO" meta:resourcekey="ListItemResource63">Dominican Republic</asp:ListItem>
<asp:ListItem value="EC" meta:resourcekey="ListItemResource64">Ecuador</asp:ListItem>
<asp:ListItem value="EG" meta:resourcekey="ListItemResource65">Egypt</asp:ListItem>
<asp:ListItem value="SV" meta:resourcekey="ListItemResource66">El Salvador</asp:ListItem>
<asp:ListItem value="GQ" meta:resourcekey="ListItemResource67">Equatorial Guinea</asp:ListItem>
<asp:ListItem value="ER" meta:resourcekey="ListItemResource68">Eritrea</asp:ListItem>
<asp:ListItem value="EE" meta:resourcekey="ListItemResource69">Estonia</asp:ListItem>
<asp:ListItem value="ET" meta:resourcekey="ListItemResource70">Ethiopia</asp:ListItem>
<asp:ListItem value="FK" meta:resourcekey="ListItemResource71">Falkland Islands (Malvinas)</asp:ListItem>
<asp:ListItem value="FO" meta:resourcekey="ListItemResource72">Faroe Islands</asp:ListItem>
<asp:ListItem value="FJ" meta:resourcekey="ListItemResource73">Fiji</asp:ListItem>
<asp:ListItem value="FI" meta:resourcekey="ListItemResource74">Finland</asp:ListItem>
<asp:ListItem value="FR" meta:resourcekey="ListItemResource75">France</asp:ListItem>
<asp:ListItem value="GF" meta:resourcekey="ListItemResource76">French Guiana</asp:ListItem>
<asp:ListItem value="PF" meta:resourcekey="ListItemResource77">French Polynesia</asp:ListItem>
<asp:ListItem value="TF" meta:resourcekey="ListItemResource78">French Southern Territories</asp:ListItem>
<asp:ListItem value="GA" meta:resourcekey="ListItemResource79">Gabon</asp:ListItem>
<asp:ListItem value="GM" meta:resourcekey="ListItemResource80">Gambia</asp:ListItem>
<asp:ListItem value="GE" meta:resourcekey="ListItemResource81">Georgia</asp:ListItem>
<asp:ListItem value="DE" meta:resourcekey="ListItemResource82">Germany</asp:ListItem>
<asp:ListItem value="GH" meta:resourcekey="ListItemResource83">Ghana</asp:ListItem>
<asp:ListItem value="GI" meta:resourcekey="ListItemResource84">Gibraltar</asp:ListItem>
<asp:ListItem value="GR" meta:resourcekey="ListItemResource85">Greece</asp:ListItem>
<asp:ListItem value="GL" meta:resourcekey="ListItemResource86">Greenland</asp:ListItem>
<asp:ListItem value="GD" meta:resourcekey="ListItemResource87">Grenada</asp:ListItem>
<asp:ListItem value="GP" meta:resourcekey="ListItemResource88">Guadeloupe</asp:ListItem>
<asp:ListItem value="GU" meta:resourcekey="ListItemResource89">Guam</asp:ListItem>
<asp:ListItem value="GT" meta:resourcekey="ListItemResource90">Guatemala</asp:ListItem>
<asp:ListItem value="GG" meta:resourcekey="ListItemResource91">Guernsey</asp:ListItem>
<asp:ListItem value="GN" meta:resourcekey="ListItemResource92">Guinea</asp:ListItem>
<asp:ListItem value="GW" meta:resourcekey="ListItemResource93">Guinea-bissau</asp:ListItem>
<asp:ListItem value="GY" meta:resourcekey="ListItemResource94">Guyana</asp:ListItem>
<asp:ListItem value="HT" meta:resourcekey="ListItemResource95">Haiti</asp:ListItem>
<asp:ListItem value="HM" meta:resourcekey="ListItemResource96">Heard Island and Mcdonald Islands</asp:ListItem>
<asp:ListItem value="VA" meta:resourcekey="ListItemResource97">Holy See (Vatican City State)</asp:ListItem>
<asp:ListItem value="HN" meta:resourcekey="ListItemResource98">Honduras</asp:ListItem>
<asp:ListItem value="HK" meta:resourcekey="ListItemResource99">Hong Kong</asp:ListItem>
<asp:ListItem value="HU" meta:resourcekey="ListItemResource100">Hungary</asp:ListItem>
<asp:ListItem value="IS" meta:resourcekey="ListItemResource101">Iceland</asp:ListItem>
<asp:ListItem value="IN" meta:resourcekey="ListItemResource102">India</asp:ListItem>
<asp:ListItem value="ID" meta:resourcekey="ListItemResource103">Indonesia</asp:ListItem>
<asp:ListItem value="IR" meta:resourcekey="ListItemResource104">Iran, Islamic Republic of</asp:ListItem>
<asp:ListItem value="IQ" meta:resourcekey="ListItemResource105">Iraq</asp:ListItem>
<asp:ListItem value="IE" meta:resourcekey="ListItemResource106">Ireland</asp:ListItem>
<asp:ListItem value="IM" meta:resourcekey="ListItemResource107">Isle of Man</asp:ListItem>
<asp:ListItem value="IL" meta:resourcekey="ListItemResource108">Israel</asp:ListItem>
<asp:ListItem value="IT" meta:resourcekey="ListItemResource109">Italy</asp:ListItem>
<asp:ListItem value="JM" meta:resourcekey="ListItemResource110">Jamaica</asp:ListItem>
<asp:ListItem value="JP" meta:resourcekey="ListItemResource111">Japan</asp:ListItem>
<asp:ListItem value="JE" meta:resourcekey="ListItemResource112">Jersey</asp:ListItem>
<asp:ListItem value="JO" meta:resourcekey="ListItemResource113">Jordan</asp:ListItem>
<asp:ListItem value="KZ" meta:resourcekey="ListItemResource114">Kazakhstan</asp:ListItem>
<asp:ListItem value="KE" meta:resourcekey="ListItemResource115">Kenya</asp:ListItem>
<asp:ListItem value="KI" meta:resourcekey="ListItemResource116">Kiribati</asp:ListItem>
<asp:ListItem value="KP" meta:resourcekey="ListItemResource117">Korea, Democratic People's Republic of</asp:ListItem>
<asp:ListItem value="KR" meta:resourcekey="ListItemResource118">Korea, Republic of</asp:ListItem>
<asp:ListItem value="KW" meta:resourcekey="ListItemResource119">Kuwait</asp:ListItem>
<asp:ListItem value="KG" meta:resourcekey="ListItemResource120">Kyrgyzstan</asp:ListItem>
<asp:ListItem value="LA" meta:resourcekey="ListItemResource121">Lao People's Democratic Republic</asp:ListItem>
<asp:ListItem value="LV" meta:resourcekey="ListItemResource122">Latvia</asp:ListItem>
<asp:ListItem value="LB" meta:resourcekey="ListItemResource123">Lebanon</asp:ListItem>
<asp:ListItem value="LS" meta:resourcekey="ListItemResource124">Lesotho</asp:ListItem>
<asp:ListItem value="LR" meta:resourcekey="ListItemResource125">Liberia</asp:ListItem>
<asp:ListItem value="LY" meta:resourcekey="ListItemResource126">Libyan Arab Jamahiriya</asp:ListItem>
<asp:ListItem value="LI" meta:resourcekey="ListItemResource127">Liechtenstein</asp:ListItem>
<asp:ListItem value="LT" meta:resourcekey="ListItemResource128">Lithuania</asp:ListItem>
<asp:ListItem value="LU" meta:resourcekey="ListItemResource129">Luxembourg</asp:ListItem>
<asp:ListItem value="MO" meta:resourcekey="ListItemResource130">Macao</asp:ListItem>
<asp:ListItem value="MK" meta:resourcekey="ListItemResource131">Macedonia, The Former Yugoslav Republic of</asp:ListItem>
<asp:ListItem value="MG" meta:resourcekey="ListItemResource132">Madagascar</asp:ListItem>
<asp:ListItem value="MW" meta:resourcekey="ListItemResource133">Malawi</asp:ListItem>
<asp:ListItem value="MY" meta:resourcekey="ListItemResource134">Malaysia</asp:ListItem>
<asp:ListItem value="MV" meta:resourcekey="ListItemResource135">Maldives</asp:ListItem>
<asp:ListItem value="ML" meta:resourcekey="ListItemResource136">Mali</asp:ListItem>
<asp:ListItem value="MT" meta:resourcekey="ListItemResource137">Malta</asp:ListItem>
<asp:ListItem value="MH" meta:resourcekey="ListItemResource138">Marshall Islands</asp:ListItem>
<asp:ListItem value="MQ" meta:resourcekey="ListItemResource139">Martinique</asp:ListItem>
<asp:ListItem value="MR" meta:resourcekey="ListItemResource140">Mauritania</asp:ListItem>
<asp:ListItem value="MU" meta:resourcekey="ListItemResource141">Mauritius</asp:ListItem>
<asp:ListItem value="YT" meta:resourcekey="ListItemResource142">Mayotte</asp:ListItem>
<asp:ListItem value="MX" meta:resourcekey="ListItemResource143">Mexico</asp:ListItem>
<asp:ListItem value="FM" meta:resourcekey="ListItemResource144">Micronesia, Federated States of</asp:ListItem>
<asp:ListItem value="MD" meta:resourcekey="ListItemResource145">Moldova, Republic of</asp:ListItem>
<asp:ListItem value="MC" meta:resourcekey="ListItemResource146">Monaco</asp:ListItem>
<asp:ListItem value="MN" meta:resourcekey="ListItemResource147">Mongolia</asp:ListItem>
<asp:ListItem value="ME" meta:resourcekey="ListItemResource148">Montenegro</asp:ListItem>
<asp:ListItem value="MS" meta:resourcekey="ListItemResource149">Montserrat</asp:ListItem>
<asp:ListItem value="MA" meta:resourcekey="ListItemResource150">Morocco</asp:ListItem>
<asp:ListItem value="MZ" meta:resourcekey="ListItemResource151">Mozambique</asp:ListItem>
<asp:ListItem value="MM" meta:resourcekey="ListItemResource152">Myanmar</asp:ListItem>
<asp:ListItem value="NA" meta:resourcekey="ListItemResource153">Namibia</asp:ListItem>
<asp:ListItem value="NR" meta:resourcekey="ListItemResource154">Nauru</asp:ListItem>
<asp:ListItem value="NP" meta:resourcekey="ListItemResource155">Nepal</asp:ListItem>
<asp:ListItem value="NL" meta:resourcekey="ListItemResource156">Netherlands</asp:ListItem>
<asp:ListItem value="AN" meta:resourcekey="ListItemResource157">Netherlands Antilles</asp:ListItem>
<asp:ListItem value="NC" meta:resourcekey="ListItemResource158">New Caledonia</asp:ListItem>
<asp:ListItem value="NZ" meta:resourcekey="ListItemResource159">New Zealand</asp:ListItem>
<asp:ListItem value="NI" meta:resourcekey="ListItemResource160">Nicaragua</asp:ListItem>
<asp:ListItem value="NE" meta:resourcekey="ListItemResource161">Niger</asp:ListItem>
<asp:ListItem value="NG" meta:resourcekey="ListItemResource162">Nigeria</asp:ListItem>
<asp:ListItem value="NU" meta:resourcekey="ListItemResource163">Niue</asp:ListItem>
<asp:ListItem value="NF" meta:resourcekey="ListItemResource164">Norfolk Island</asp:ListItem>
<asp:ListItem value="MP" meta:resourcekey="ListItemResource165">Northern Mariana Islands</asp:ListItem>
<asp:ListItem value="NO" meta:resourcekey="ListItemResource166">Norway</asp:ListItem>
<asp:ListItem value="OM" meta:resourcekey="ListItemResource167">Oman</asp:ListItem>
<asp:ListItem value="PK" meta:resourcekey="ListItemResource168">Pakistan</asp:ListItem>
<asp:ListItem value="PW" meta:resourcekey="ListItemResource169">Palau</asp:ListItem>
<asp:ListItem value="PS" meta:resourcekey="ListItemResource170">Palestinian Territory, Occupied</asp:ListItem>
<asp:ListItem value="PA" meta:resourcekey="ListItemResource171">Panama</asp:ListItem>
<asp:ListItem value="PG" meta:resourcekey="ListItemResource172">Papua New Guinea</asp:ListItem>
<asp:ListItem value="PY" meta:resourcekey="ListItemResource173">Paraguay</asp:ListItem>
<asp:ListItem value="PE" meta:resourcekey="ListItemResource174">Peru</asp:ListItem>
<asp:ListItem value="PH" meta:resourcekey="ListItemResource175">Philippines</asp:ListItem>
<asp:ListItem value="PN" meta:resourcekey="ListItemResource176">Pitcairn</asp:ListItem>
<asp:ListItem value="PL" meta:resourcekey="ListItemResource177">Poland</asp:ListItem>
<asp:ListItem value="PT" meta:resourcekey="ListItemResource178">Portugal</asp:ListItem>
<asp:ListItem value="PR" meta:resourcekey="ListItemResource179">Puerto Rico</asp:ListItem>
<asp:ListItem value="QA" meta:resourcekey="ListItemResource180">Qatar</asp:ListItem>
<asp:ListItem value="RE" meta:resourcekey="ListItemResource181">Reunion</asp:ListItem>
<asp:ListItem value="RO" meta:resourcekey="ListItemResource182">Romania</asp:ListItem>
<asp:ListItem value="RU" meta:resourcekey="ListItemResource183">Russian Federation</asp:ListItem>
<asp:ListItem value="RW" meta:resourcekey="ListItemResource184">Rwanda</asp:ListItem>
<asp:ListItem value="SH" meta:resourcekey="ListItemResource185">Saint Helena</asp:ListItem>
<asp:ListItem value="KN" meta:resourcekey="ListItemResource186">Saint Kitts and Nevis</asp:ListItem>
<asp:ListItem value="LC" meta:resourcekey="ListItemResource187">Saint Lucia</asp:ListItem>
<asp:ListItem value="PM" meta:resourcekey="ListItemResource188">Saint Pierre and Miquelon</asp:ListItem>
<asp:ListItem value="VC" meta:resourcekey="ListItemResource189">Saint Vincent and The Grenadines</asp:ListItem>
<asp:ListItem value="WS" meta:resourcekey="ListItemResource190">Samoa</asp:ListItem>
<asp:ListItem value="SM" meta:resourcekey="ListItemResource191">San Marino</asp:ListItem>
<asp:ListItem value="ST" meta:resourcekey="ListItemResource192">Sao Tome and Principe</asp:ListItem>
<asp:ListItem value="SA" meta:resourcekey="ListItemResource193">Saudi Arabia</asp:ListItem>
<asp:ListItem value="SN" meta:resourcekey="ListItemResource194">Senegal</asp:ListItem>
<asp:ListItem value="RS" meta:resourcekey="ListItemResource195">Serbia</asp:ListItem>
<asp:ListItem value="SC" meta:resourcekey="ListItemResource196">Seychelles</asp:ListItem>
<asp:ListItem value="SL" meta:resourcekey="ListItemResource197">Sierra Leone</asp:ListItem>
<asp:ListItem value="SG" meta:resourcekey="ListItemResource198">Singapore</asp:ListItem>
<asp:ListItem value="SK" meta:resourcekey="ListItemResource199">Slovakia</asp:ListItem>
<asp:ListItem value="SI" meta:resourcekey="ListItemResource200">Slovenia</asp:ListItem>
<asp:ListItem value="SB" meta:resourcekey="ListItemResource201">Solomon Islands</asp:ListItem>
<asp:ListItem value="SO" meta:resourcekey="ListItemResource202">Somalia</asp:ListItem>
<asp:ListItem value="ZA" meta:resourcekey="ListItemResource203">South Africa</asp:ListItem>
<asp:ListItem value="GS" meta:resourcekey="ListItemResource204">South Georgia and The South Sandwich Islands</asp:ListItem>
<asp:ListItem value="ES" meta:resourcekey="ListItemResource205">Spain</asp:ListItem>
<asp:ListItem value="LK" meta:resourcekey="ListItemResource206">Sri Lanka</asp:ListItem>
<asp:ListItem value="SD" meta:resourcekey="ListItemResource207">Sudan</asp:ListItem>
<asp:ListItem value="SR" meta:resourcekey="ListItemResource208">Suriname</asp:ListItem>
<asp:ListItem value="SJ" meta:resourcekey="ListItemResource209">Svalbard and Jan Mayen</asp:ListItem>
<asp:ListItem value="SZ" meta:resourcekey="ListItemResource210">Swaziland</asp:ListItem>
<asp:ListItem value="SE" meta:resourcekey="ListItemResource211">Sweden</asp:ListItem>
<asp:ListItem value="CH" meta:resourcekey="ListItemResource212">Switzerland</asp:ListItem>
<asp:ListItem value="SY" meta:resourcekey="ListItemResource213">Syrian Arab Republic</asp:ListItem>
<asp:ListItem value="TW" meta:resourcekey="ListItemResource214">Taiwan, Province of China</asp:ListItem>
<asp:ListItem value="TJ" meta:resourcekey="ListItemResource215">Tajikistan</asp:ListItem>
<asp:ListItem value="TZ" meta:resourcekey="ListItemResource216">Tanzania, United Republic of</asp:ListItem>
<asp:ListItem value="TH" meta:resourcekey="ListItemResource217">Thailand</asp:ListItem>
<asp:ListItem value="TL" meta:resourcekey="ListItemResource218">Timor-leste</asp:ListItem>
<asp:ListItem value="TG" meta:resourcekey="ListItemResource219">Togo</asp:ListItem>
<asp:ListItem value="TK" meta:resourcekey="ListItemResource220">Tokelau</asp:ListItem>
<asp:ListItem value="TO" meta:resourcekey="ListItemResource221">Tonga</asp:ListItem>
<asp:ListItem value="TT" meta:resourcekey="ListItemResource222">Trinidad and Tobago</asp:ListItem>
<asp:ListItem value="TN" meta:resourcekey="ListItemResource223">Tunisia</asp:ListItem>
<asp:ListItem value="TR" meta:resourcekey="ListItemResource224">Turkey</asp:ListItem>
<asp:ListItem value="TM" meta:resourcekey="ListItemResource225">Turkmenistan</asp:ListItem>
<asp:ListItem value="TC" meta:resourcekey="ListItemResource226">Turks and Caicos Islands</asp:ListItem>
<asp:ListItem value="TV" meta:resourcekey="ListItemResource227">Tuvalu</asp:ListItem>
<asp:ListItem value="UG" meta:resourcekey="ListItemResource228">Uganda</asp:ListItem>
<asp:ListItem value="UA" meta:resourcekey="ListItemResource229">Ukraine</asp:ListItem>
<asp:ListItem value="AE" meta:resourcekey="ListItemResource230">United Arab Emirates</asp:ListItem>
<asp:ListItem value="GB" meta:resourcekey="ListItemResource231">United Kingdom</asp:ListItem>
<asp:ListItem value="US" meta:resourcekey="ListItemResource232">United States</asp:ListItem>
<asp:ListItem value="UM" meta:resourcekey="ListItemResource233">United States Minor Outlying Islands</asp:ListItem>
<asp:ListItem value="UY" meta:resourcekey="ListItemResource234">Uruguay</asp:ListItem>
<asp:ListItem value="UZ" meta:resourcekey="ListItemResource235">Uzbekistan</asp:ListItem>
<asp:ListItem value="VU" meta:resourcekey="ListItemResource236">Vanuatu</asp:ListItem>
<asp:ListItem value="VE" meta:resourcekey="ListItemResource237">Venezuela</asp:ListItem>
<asp:ListItem value="VN" meta:resourcekey="ListItemResource238">Viet Nam</asp:ListItem>
<asp:ListItem value="VG" meta:resourcekey="ListItemResource239">Virgin Islands, British</asp:ListItem>
<asp:ListItem value="VI" meta:resourcekey="ListItemResource240">Virgin Islands, U.S.</asp:ListItem>
<asp:ListItem value="WF" meta:resourcekey="ListItemResource241">Wallis and Futuna</asp:ListItem>
<asp:ListItem value="EH" meta:resourcekey="ListItemResource242">Western Sahara</asp:ListItem>
<asp:ListItem value="YE" meta:resourcekey="ListItemResource243">Yemen</asp:ListItem>
<asp:ListItem value="ZM" meta:resourcekey="ListItemResource244">Zambia</asp:ListItem>
<asp:ListItem value="ZW" meta:resourcekey="ListItemResource245">Zimbabwe</asp:ListItem>

                                </asp:DropDownList>
                                
                                
                                
                                
                                
                                
                                
                                <div class="separator"></div>
                                
                                <p><asp:Literal ID="Literal17" runat="server" Text="Città" meta:resourcekey="Literal17Resource1"></asp:Literal></p>
                                <asp:TextBox ClientIDMode="Static" ID="inputTitle" class="span6" placeholder="" runat="server" meta:resourcekey="inputTitleResource1"></asp:TextBox>

								<div class="separator"></div>
                                <p><asp:Literal ID="Literal18" runat="server" Text="Provincia" meta:resourcekey="Literal18Resource1"></asp:Literal></p>
								<asp:TextBox ClientIDMode="Static" ID="Text1" class="span6" placeholder="" runat="server" meta:resourcekey="Text1Resource1"></asp:TextBox>

                                <div class="separator"></div>
								<p><asp:Literal ID="Literal19" runat="server" Text="via" meta:resourcekey="Literal19Resource1"></asp:Literal></p>
                                <asp:TextBox ClientIDMode="Static" ID="Text2" class="span6" placeholder="" runat="server" meta:resourcekey="Text2Resource1"></asp:TextBox>

								<div class="separator"></div>
								<p><asp:Literal ID="Literal20" runat="server" Text="numero" meta:resourcekey="Literal20Resource1"></asp:Literal></p>
                                <asp:TextBox ClientIDMode="Static" ID="Text3" class="span6" placeholder="" runat="server" meta:resourcekey="Text3Resource1"></asp:TextBox>

								<div class="separator"></div>
                                
                          </div>
						</div>
					</div>
					<!-- // Step 2 END -->
					
					<!-- Step 3 -->
					<div class="tab-pane" id="tab5">
                    <div class="row-fluid">
                   <div class="span3">
                       <h4><asp:Literal ID="Literal21" runat="server" Text="Referente" meta:resourcekey="Literal21Resource1"></asp:Literal></h4>
						<p><asp:Literal ID="Literal22" runat="server" Text="Inserisci informazioni relative alla persona referente di questo impianto" meta:resourcekey="Literal22Resource1"></asp:Literal></p>
                        		</div>
                                <div class="span9">
                                    <p><asp:Literal ID="Literal23" runat="server" Text="Nome" meta:resourcekey="Literal23Resource1"></asp:Literal></p>
                                    <asp:TextBox ClientIDMode="Static" ID="Text4" class="span6" placeholder="" runat="server" meta:resourcekey="Text4Resource1"></asp:TextBox>


								<div class="separator"></div>
                                    <p><asp:Literal ID="Literal25" runat="server" Text="Recapito telefonico" meta:resourcekey="Literal25Resource1"></asp:Literal></p>
                                    <asp:TextBox ClientIDMode="Static" ID="Text6" class="span6" placeholder="" runat="server" meta:resourcekey="Text6Resource1"></asp:TextBox>

								<div class="separator"></div>
                                    <p><asp:Literal ID="Literal26" runat="server" Text="Email" meta:resourcekey="Literal26Resource1"></asp:Literal></p>
                                    <asp:TextBox ClientIDMode="Static" ID="Text7" class="span6" placeholder="" runat="server" meta:resourcekey="Text7Resource1"></asp:TextBox>
							
                            	<div class="separator"></div>
                                </div>
                                </div>
 
					</div>
					<!-- // Step 3 END -->
					<!-- Step 4 -->
					<div class="tab-pane" id="tab6">
<div class="row-fluid">
                   <div class="span3">
                       <h4><asp:Literal ID="Literal27" runat="server" Text="Utilizzatore" meta:resourcekey="Literal27Resource1"></asp:Literal></h4>
                       <p><asp:Literal ID="Literal28" runat="server" Text="Inserisci informazioni relative alla persona Utilizzatore dell' impianto" meta:resourcekey="Literal28Resource1"></asp:Literal></p>
                       <p style="color:red;"><asp:Literal ID="Literal24" runat="server" Text="Attenzione L'Utilizzatore è una persona delegata dal referente alla gestione dell'impianto" meta:resourcekey="Literal24Resource1"></asp:Literal></p>
                        		</div>
                                <div class="span9">

                            <p><asp:Literal ID="Literal50" runat="server" Text="Seleziona un Utilizzatore" meta:resourcekey="Literal50Resource1"></asp:Literal></p>

								<asp:DropDownList ClientIDMode="Static" ID="utilizzatore_list" runat="server" meta:resourcekey="utilizzatore_listResource1">
                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource246">Nessuno..</asp:ListItem>
                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource247">Nuovo</asp:ListItem>
								</asp:DropDownList>
<div id ="enable_utilizzatore">
                                <div class="separator"></div>
                                    <p><asp:Literal ID="Literal60" runat="server" Text="Nome" meta:resourcekey="Literal60Resource1" ></asp:Literal></p>
                                    <asp:TextBox ClientIDMode="Static" ID="Text12" class="span6" placeholder="" onblur="javascript: Changed_channel( 'Text12',0);" runat="server" meta:resourcekey="Text12Resource1"></asp:TextBox>

                                <div class="separator"></div>
                                    <p><asp:Literal ID="Literal29" runat="server" Text="Username" meta:resourcekey="Literal29Resource1" ></asp:Literal></p>
                                    <asp:TextBox ClientIDMode="Static" ID="Text9" class="span6" placeholder="" onblur="javascript: Changed_channel( 'Text9',6);" runat="server" meta:resourcekey="Text9Resource1"></asp:TextBox>

								<div class="separator"></div>
                                    <p><asp:Literal ID="Literal30" runat="server" Text="Password" meta:resourcekey="Literal30Resource1"></asp:Literal></p>
                                    <asp:TextBox ClientIDMode="Static" ID="Text10" class="span6" placeholder="" onblur="javascript: Changed_channel( 'Text10',6);" runat="server" meta:resourcekey="Text10Resource1"></asp:TextBox>

    <div class="separator"></div>
                                    <p><asp:Literal ID="Literal31" runat="server" Text="Modifica SetPoint" meta:resourcekey="Literal31Resource1"></asp:Literal></p>
                                    <asp:CheckBox ClientIDMode="Static" ID="check1" class="span6" runat="server" meta:resourcekey="check1Resource1" />
                                </div>								
                            	<div class="separator"></div>
                                </div>
                                </div>
										</div>
					<!-- // Step 4 END -->
                    <!-- Step 5 -->
					<div class="tab-pane active" id="tab1">
                        <div class="row-fluid">
                   <div class="span3">
                       <h4><asp:Literal ID="Literal32" runat="server" Text="Sito dell'Impianto" meta:resourcekey="Literal32Resource1"></asp:Literal></h4>
						<p><asp:Literal ID="Literal33" runat="server" Text="Aggiungi il nuovo impianto ad un Sito" meta:resourcekey="Literal33Resource1"></asp:Literal></p>
                        </div>
                        <div class="span9">
								<p><asp:Literal ID="Literal34" runat="server" Text="Seleziona un Sito già esistente" meta:resourcekey="Literal34Resource1"></asp:Literal></p>
								<asp:DropDownList ClientIDMode="Static" ID="gruppi" runat="server" meta:resourcekey="gruppiResource1">
                                    <asp:ListItem Value="nuovo" meta:resourcekey="ListItemResource248">Nuovo..</asp:ListItem>
                                    <asp:ListItem Value="emec>emec1" meta:resourcekey="ListItemResource249">emec</asp:ListItem>
								</asp:DropDownList>
								
                                <div class="separator"></div>
                            <p><asp:Literal ID="Literal35" runat="server" Text="Crea un nuovo Sito" meta:resourcekey="Literal35Resource1"></asp:Literal></p>
                            <asp:TextBox ClientIDMode="Static" ID="textGruppo" class="span6" placeholder=""  onblur="javascript: Changed_channel( 'textGruppo',0);" runat="server" meta:resourcekey="textGruppoResource1"></asp:TextBox>
                        </div>
                        </div>
					</div>
					<!-- // Step 5 END -->
					
					<!-- Step 6 -->
					<div class="tab-pane" id="tab2">
                        <div class="row-fluid">
                   <div class="span3">

                       <h4><asp:Literal ID="Literal36" runat="server" Text="Impianto" meta:resourcekey="Literal36Resource1"></asp:Literal></h4>
						<p><asp:Literal ID="Literal37" runat="server" Text="Aggiungi un nome al nuovo Impianto" meta:resourcekey="Literal37Resource1"></asp:Literal></p>

                        </div>
                        <div class="span9">

                            <p><asp:Literal ID="Literal38" runat="server" Text="Seleziona Impianto già Esistente" meta:resourcekey="Literal38Resource1"></asp:Literal></p>								
								<asp:DropDownList ClientIDMode="Static" ID="sottogruppi" runat="server" meta:resourcekey="sottogruppiResource1">
                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource250">Nuovo..</asp:ListItem>
                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource251">Italy - Roma - via arice, 1</asp:ListItem>
								</asp:DropDownList>
                                <div class="separator"></div>
                            <p><asp:Literal ID="Literal39" runat="server" Text="Crea un nuovo Impianto" meta:resourcekey="Literal39Resource1"></asp:Literal></p>	
                            <asp:TextBox  ID="Text11" ClientIDMode="Static" class="span6" placeholder=""  onblur="javascript: Changed_channel( 'Text11',0);" runat="server" meta:resourcekey="Text11Resource1"></asp:TextBox>
                        </div>
                        </div>
					</div>
					<!-- // Step 6 END -->
				</div>
				<!-- Wizard pagination controls -->
				<div class="pagination margin-bottom-none">
					<ul>
						<li class="primary previous first"><a href="javascript:;"><asp:Literal ID="Literal40" runat="server" Text="First" meta:resourcekey="Literal40Resource1"></asp:Literal></a></li>
						<li class="primary previous"><a href="javascript:;"><asp:Literal ID="Literal41" runat="server" Text="Previous" meta:resourcekey="Literal41Resource1"></asp:Literal></a></li>
						<li class="last primary"><a href="javascript:;"><asp:Literal ID="Literal42" runat="server" Text="Last" meta:resourcekey="Literal42Resource1"></asp:Literal></a></li>
					  	<li class="next primary"><a href="javascript:;"><asp:Literal ID="Literal43" runat="server" Text="Next" meta:resourcekey="Literal43Resource1"></asp:Literal></a></li>
						<li class="next finish primary" style="display:none;"><asp:button ClientIDMode="Static" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" runat="server" Text="Finish" ID="save_impianto_new" meta:resourcekey="save_impianto_newResource1"  /></li>
					</ul>
				</div>
				<!-- // Wizard pagination controls END -->
				
			</div>
		</div>
        </div>
	</div>
	<!-- // Form Wizard / Arrow navigation & Progress bar END -->
       </div>
        </div>
      
		<div class="clearfix"></div>
   <script type="text/javascript" src="common/validator_general_addimpianto.js"></script>
    <script type="text/javascript" src="common/validator_general_notify.js"></script>
    <script>manage_nuovi_impianti();</script>
      
    </asp:Content>
    
<asp:Content ID="Content4" ContentPlaceHolderID="script_at_end" runat="server">
    <script src="theme/scripts/demo/notifications.js"></script>
      <script >
          var sPageURL = window.location.search.substring(1);
          var i = 0;
          var val;
          var indice = 0;
          var pagina_split = sPageURL.split('&');

          for (i = 0; i < pagina_split.length; i++) {
              val = pagina_split[i].split("=");
              if (val[0] == 'result') {
                  var risultato = parseInt(val[1]);
                  if (risultato == 1) { //risposta corretta
                      result_setpoint_change(add_account_ok);
                  }
                  if (risultato == 2) { //strumento occupato
                      result_setpoint_change(add_account_error);
                  }

              }
          }
</script>
</asp:Content>

  
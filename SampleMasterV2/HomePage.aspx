<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="SampleMasterV2.WebForm1" %>
<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <link href="bootstrap/css/styles.css" rel="stylesheet" />
    
         <!-- Masthead-->
 
        <header class="masthead">
            <div class="container">
                
                <div class="masthead-subheading">Limitless Paper in a Paperless World</div>
                <div class="masthead-heading text-uppercase">Inkpress Solutions</div>
                <a class="btn btn-primary btn-xl text-uppercase" href="#about">Wanna know more?</a>
            </div>
        </header>
 

     <!-- Portfolio Grid-->
        <section class="page-section bg-light" id="portfolio">
            <div class="container">
                <div class="text-center">
                    <h2 class="section-heading text-uppercase">Our Products</h2>
                </div>
                <div class="row">
                    <div class="col-lg-3 col-sm-6 mb-4">
                        <!-- Portfolio item 1 dito lagay 1st product-->
                        <div class="portfolio-item">
                            <a class="portfolio-link" data-bs-toggle="modal" href="#portfolioModal1">
                                <div class="portfolio-hover">
                                    <div class="portfolio-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid" src="pics/prod1.jpg" alt="..." />
                            </a>
                            <div class="portfolio-caption">
                                <div class="portfolio-caption-heading">Bond Papers</div>
                                
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-sm-6 mb-4">
                        <!-- Portfolio item 2-->
                        <div class="portfolio-item">
                            <a class="portfolio-link" data-bs-toggle="modal" href="#portfolioModal2">
                                <div class="portfolio-hover">
                                    <div class="portfolio-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid" src="pics/prod2.jpg" alt="..." />
                            </a>
                            <div class="portfolio-caption">
                                <div class="portfolio-caption-heading">Cardstock Papers</div>
                                
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-sm-6 mb-4">
                        <!-- Portfolio item 3-->
                        <div class="portfolio-item">
                            <a class="portfolio-link" data-bs-toggle="modal" href="#portfolioModal3">
                                <div class="portfolio-hover">
                                    <div class="portfolio-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid" src="pics/prod3.jpg" alt="..." />
                            </a>
                            <div class="portfolio-caption">
                                <div class="portfolio-caption-heading">Sticker Papers</div>
                                
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-sm-6 mb-4">
                        <!-- Portfolio item 4-->
                        <div class="portfolio-item">
                            <a class="portfolio-link" data-bs-toggle="modal" href="#portfolioModal4">
                                <div class="portfolio-hover">
                                    <div class="portfolio-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid" src="pics/prod4.jpg" alt="..." />
                            </a>
                            <div class="portfolio-caption">
                                <div class="portfolio-caption-heading">Laminating Films</div>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    
    <!-- About-->
        <section class="page-section" id="about">
            <div class="container">
                <div class="text-center">
                    <h2 class="section-heading text-uppercase">About</h2>
                    <h3 class="section-subheading text-muted">Inkpress Solutions</h3>
                </div>
                <ul class="timeline">
                    <li>
                        <div class="timeline-image"><img class="rounded-circle img-fluid" src="pics/about1.jpg" alt="..." /></div>
                        <div class="timeline-panel">
                            <div class="timeline-heading">
                                <h4 class="subheading">Who Are We?</h4>
                            </div>
                            <div class="timeline-body"><p class="text-muted">InkPress Solutions was established by three entrepreneur students in the city of Binan, Laguna. It aims to provide the needs of micro and small printing enterprises through remarkable and high quality products.</p></div>
                        </div>
                    </li>
                    <li class="timeline-inverted">
                        <div class="timeline-image"><img class="rounded-circle img-fluid" src="pics/about2.jpg" alt="..." /></div>
                        <div class="timeline-panel">
                            <div class="timeline-heading">
                                <h4 class="subheading">Our Humble Beginnings</h4>
                            </div>
                            <div class="timeline-body"><p class="text-muted">On the day January 19, 2021, InkPress Solution opened its doors. Located at San Jose Village 3, Binan, Philippines, 4024.</p></div>
                        </div>
                    </li>
                    <li>
                        <div class="timeline-image"><img class="rounded-circle img-fluid" src="pics/about3.jpg" alt="..." /></div>
                        <div class="timeline-panel">
                            <div class="timeline-heading">
                                <h4 class="subheading">Mission</h4>
                            </div>
                            <div class="timeline-body"><p class="text-muted">To be a reliable partner in building brand identity of business through producing quality
papers.</p></div>
                        </div>
                    </li>
                    <li class="timeline-inverted">
                        <div class="timeline-image"><img class="rounded-circle img-fluid" src="pics/about4.jpg" alt="..." /></div>
                        <div class="timeline-panel">
                            <div class="timeline-heading">
                                <h4 class="subheading">Vision</h4>
                            </div>
                            <div class="timeline-body"><p class="text-muted">To be the leading paper selling enterprise and most preferred paper selling business among micro and small businesses in the province Laguna in the next 10 years.</p></div>
                        </div>
                    </li>
                    <li class="timeline-inverted">
                        <div class="timeline-image">
                            <h4>
                                Be Part
                                <br />
                                Of Our
                                <br />
                                Story!
                            </h4>
                        </div>
                    </li>
                <%--</ul>--%>
            </div>
        </section>
            <!-- Portfolio Modals-->
        <!-- Portfolio item 1 modal popup-->
        <div class="portfolio-modal modal fade" id="portfolioModal1" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="close-modal" data-bs-dismiss="modal"><img src="pics/close-icon.svg" alt="Close modal" /></div>
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-8">
                                <div class="modal-body">
                                    <!-- Project details-->
                                    <h2 class="text-uppercase">Bond Paper</h2>
                                    <p class="item-intro text-muted"></p>
                                    <img class="img-fluid d-block mx-auto" src="pics/prod1.jpg" alt="..." />
                                    <p>Best Buy Bond paper is a durable, high-quality writing paper that holds ink well and is resistant to tearing and fraying. It is ideal for professional documents that need to look neat and tidy.</p>
                                    <button class="btn btn-primary btn-xl text-uppercase" data-bs-dismiss="modal" type="button">
                                        <i class="fas fa-xmark me-1"></i>
                                        Close Project
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Portfolio item 2 modal popup-->
        <div class="portfolio-modal modal fade" id="portfolioModal2" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="close-modal" data-bs-dismiss="modal"><img src="pics/close-icon.svg" alt="Close modal" /></div>
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-8">
                                <div class="modal-body">
                                    <!-- Project details-->
                                    <h2 class="text-uppercase">Cardstock Paper</h2>
                                    <p class="item-intro text-muted"></p>
                                    <img class="img-fluid d-block mx-auto" src="pics/prod2.jpg" alt="..." />
                                    <p>Quaff Cardstock paper is a thick, heavy paper that is commonly used for crafting, scrapbooking, and printing projects that require a sturdy material. It is ideal for creating cards, invitations, and other paper products that need to be more substantial than regular paper. Its thickness and weight also make it more durable and resistant to wear and tear.</p>

                                    <button class="btn btn-primary btn-xl text-uppercase" data-bs-dismiss="modal" type="button">
                                        <i class="fas fa-xmark me-1"></i>
                                        Close Project
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Portfolio item 3 modal popup-->
        <div class="portfolio-modal modal fade" id="portfolioModal3" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="close-modal" data-bs-dismiss="modal"><img src="pics/close-icon.svg" alt="Close modal" /></div>
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-8">
                                <div class="modal-body">
                                    <!-- Project details-->
                                    <h2 class="text-uppercase">Sticker Paper</h2>
                                    <p class="item-intro text-muted"></p>
                                    <img class="img-fluid d-block mx-auto" src="pics/prod3.jpg" alt="..." />
                                    <p>iTech Sticker paper is a type of adhesive-backed paper that can be used to create custom stickers for a variety of purposes, including branding, labeling, and decoration. Its backing is usually coated with a strong adhesive that allows the sticker to be easily applied and removed without leaving residue or damaging surfaces. If you want to create custom stickers for personal or business use, sticker paper is a convenient and versatile option.</p>

                                    <button class="btn btn-primary btn-xl text-uppercase" data-bs-dismiss="modal" type="button">
                                        <i class="fas fa-xmark me-1"></i>
                                        Close Project
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Portfolio item 4 modal popup-->

        <div class="portfolio-modal modal fade" id="portfolioModal4" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="close-modal" data-bs-dismiss="modal"><img src="pics/close-icon.svg" alt="Close modal" /></div>
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-8">
                                <div class="modal-body">
                                    <!-- Project details-->
                                    <h2 class="text-uppercase">Laminating Film</h2>
                                    <p class="item-intro text-muted"></p>
                                    <img class="img-fluid d-block mx-auto" src="pics/prod4.jpg" alt="..." />
                                    <p>Quaff Laminating film is a transparent plastic film that can be used to protect and preserve paper documents, such as photos, certificates, and posters. It is applied using a laminator, which heats and fuses the film to the paper, creating a durable and waterproof seal. Laminating film is ideal for protecting important documents from damage caused by moisture, tearing, or staining, and can help extend their lifespan. If you want to protect your documents and keep them looking new, laminating film is a great option.</p>
                                    <button class="btn btn-primary btn-xl text-uppercase" data-bs-dismiss="modal" type="button">
                                        <i class="fas fa-xmark me-1"></i>
                                        Close Project
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

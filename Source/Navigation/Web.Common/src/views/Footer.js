import React from 'react';

import '../assets/footer.scss';

export default class extends React.Component {
  componentDidMount() {
    let links = document.querySelectorAll('footer a');

    // IE doesn't support NodeList.forEach, so we need to convert links to
    // an array first.
    links = Array.from(links);

    links.forEach(anchor => {
      anchor.target = '_blank';
      anchor.rel = 'noopener noreferrer';
    });
  }

  render() {
    return (
      <footer>
        <div className="container">
          <div className="row">
            <div className="col-md-4 pull-left footer-logo">
              <svg className="pull-left" xmlns="http://www.w3.org/2000/svg" width="60" height="60" viewBox="0 0 60 60">
                <title>
                  The Red Cross
                </title>
                <g fill="none" fillRule="evenodd">
                  <path fill="#F2F2F2" d="M60 60H0V0h60v60z"></path>
                  <path fill="#D52B1E" d="M24 36v12h12V36h12V24H36V12H24v12H12v12h12z"></path>
                </g>
              </svg>
              <h4 className="pull-left">Norwegian Red Cross</h4>
            </div>

            <div className="col-md-4">
              <nav>
                <ul>
                  <li><a href="https://www.rodekors.no/en/english-pages/">About Us</a></li>
                  <li><a href="https://www.rodekors.no/en/english-pages/international-strategy/">International Strategy</a></li>
                  <li><a href="https://www.rodekors.no/om-rode-kors/presse/">Pressroom</a></li>
                  <li><a href="https://www.rodekors.no/om-rode-kors/kontaktinformasjon/">Contact Information</a></li>
                  <li className="footer-social">
                    <ul>
                      <li>
                        <a href="https://twitter.com/rodekorsnorge" title="Norwegian RedCross on Twitter">
                        <svg width="18" height="18" viewBox="0 0 18 18" xmlns="http://www.w3.org/2000/svg"><title>twitter</title><path d="M18 3.775a7.23 7.23 0 0 1-2.12.596 3.788 3.788 0 0 0 1.623-2.093 7.33 7.33 0 0 1-2.347.92A3.64 3.64 0 0 0 12.46 2c-2.038 0-3.69 1.696-3.69 3.787 0 .297.03.586.094.863-3.068-.158-5.79-1.666-7.61-3.958-.318.56-.5 1.21-.5 1.904 0 1.315.653 2.474 1.643 3.153a3.622 3.622 0 0 1-1.673-.477v.048c0 1.836 1.274 3.367 2.962 3.715-.31.086-.636.133-.973.133-.238 0-.47-.024-.695-.07.47 1.505 1.833 2.6 3.448 2.63A7.29 7.29 0 0 1 0 15.297 10.247 10.247 0 0 0 5.66 17c6.793 0 10.505-5.772 10.505-10.778l-.012-.49A7.48 7.48 0 0 0 18 3.775z" fill="#010002" fillRule="evenodd"></path></svg>
                      </a>
                      </li>
                      <li><a href="https://facebook.com/rodekors/" title="Norwegian RedCross on Facebook">
                        <svg width="18" height="18" viewBox="0 0 18 18" xmlns="http://www.w3.org/2000/svg"><title>facebook</title><path d="M15.227 2H2.773A.773.773 0 0 0 2 2.773v12.454c0 .427.346.773.773.773h6.705v-5.422H7.653V8.466h1.825v-1.56c0-1.807 1.104-2.792 2.717-2.792.773 0 1.437.058 1.63.084v1.89h-1.118c-.877 0-1.047.417-1.047 1.03v1.348h2.092l-.272 2.112h-1.82V16h3.567a.773.773 0 0 0 .773-.773V2.773A.773.773 0 0 0 15.227 2" fill="#000" fillRule="evenodd"></path></svg>
                      </a>
                      </li>
                    </ul>
                  </li>
                </ul>
              </nav>
            </div>

            <div className="col-md-4">
              <nav>
                <ul>
                  <li><a href="https://cbsrc.org/cbs/">About CBS</a></li>
                  <li><a href="https://cbsrc.org/contactus/">Contact Us</a></li>
                  <li><a href="https://cbsrc.org/contribute/">Get Involved</a></li>
                  <li><a href="https://medium.com/redcrosscbs">Blog</a></li>
                  <li><a href="https://cbsv2.slack.com/">CBS on Slack</a></li>
                  <li><a href="https://github.com/ifrcgo/cbs">CBS on GitHub</a></li>
                </ul>
              </nav>
            </div>
          </div>

          <div className="footer-secondary">
            <ul>
              <li><a href="https://www.rodekors.no/om-rode-kors/behandlingsgrunnlag/">Privacy</a></li>
              <li><a href="#">Cookies</a></li>
              <li><a href="#">Legal</a></li>
            </ul>
            <p>©{new Date().getFullYear()} Community Based Surveillance</p>
          </div>
        </div>

      </footer>
    );
  }
}

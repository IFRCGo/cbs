import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'cbs-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'cbs';
  selected_lang: any;
  language = [
    { text: 'English', value: 'en', selected: false },
    { text: 'French', value: 'fr', selected: false}
  ]
  constructor(private translate: TranslateService) {}

    ngOnInit() {
      this.initialLanguage();
    }

    changeLang(e) {
      const lang_stored = e.target.value;
      if (lang_stored !== '') {
        this.setSelectedLanguage(lang_stored);
        localStorage.setItem('lang', lang_stored);
        this.translate.use(lang_stored);
      }
    }

    initialLanguage() {
      let lang;
      const lang_stored = localStorage.getItem('lang');
      if (lang_stored && this.language.map(_ => _.value).includes(lang_stored)) {
        lang = lang_stored;
      }
      else {
        let browser_lang = this.translate.getBrowserLang();
        if (browser_lang === '' || !this.language.map(_ => _.value).includes(browser_lang)) browser_lang = 'en';
        lang = browser_lang;
      }
      this.setSelectedLanguage(lang);
      this.translate.setDefaultLang(lang);
      localStorage.setItem('lang', lang);
      this.translate.use(lang_stored);
      this.selected_lang = lang_stored;
      
    }

    setSelectedLanguage(lang) {
      this.language[this.language.findIndex(_ => _.value === lang)].selected = true;
    }

}


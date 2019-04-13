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
    { text: 'English', value: 'en' },
    { text: 'French', value: 'fr'}
  ]
  constructor(private translate: TranslateService) {}

    ngOnInit() {
    this.initialLanguage();
    }

    changeLang(e) {
      const lang_stored = e.target.value;
      console.log(lang_stored);
      if (lang_stored !== '') {
        localStorage.setItem('lang', lang_stored);
        this.translate.use(lang_stored);
      }
    }

    initialLanguage() {
      const lang = this.translate.getBrowserLang();
      this.translate.setDefaultLang(lang);
      console.log(lang);

      const lang_stored = localStorage.getItem('lang');
      if (lang_stored) {
        console.log(lang_stored);
        this.translate.use(lang_stored);
        this.selected_lang = lang_stored;
      }
    }

}


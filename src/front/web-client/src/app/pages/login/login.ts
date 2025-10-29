import { Component, computed, signal } from '@angular/core';
import { LoginPageTemplate } from './login-page-template/login-page-template';

@Component({
  selector: 'app-login',
  imports: [LoginPageTemplate],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {
  // Signaux pour les champ
  public email = signal('');
  public password = signal('');
  passwordVisible = signal(false);

  // Signaux pour les erreurs
  emailErrors = computed(() => {
    const value = this.email();
    if (!value) return 'Email requis';
    if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(value)) return 'Email invalide';
    return null;
  });

  passwordErrors = computed(() => {
    const value = this.password();
    if (!value) return 'Mot de passe requis';
    if (value.length < 6) return 'Minimum 6 caractères';
    return null;
  });

  // Validation globale
  isFormValid = computed(() => !this.emailErrors() && !this.passwordErrors());

  togglePasswordVisibility(): void {
    this.passwordVisible.set(!this.passwordVisible());
  }

  // Soumission
  submit() {
    if (this.isFormValid()) {
      console.log('Connexion avec :', {
        email: this.email(),
        password: this.password(),
      });
      // Appel à un service d'authentification ici
    } else {
      console.warn('Formulaire invalide');
    }
  }
}

import { Injectable } from '@angular/core';
import packageJson from '../../../package.json';

@Injectable({
  providedIn: 'root',
})
export class ConfigService {
  private static AppConfig?: Config;

  static async loadConfigFile(): Promise<Config> {
    const response = await fetch(`assets/config.json?v=${packageJson.version}`);
    const data: Config = await response.json();
    ConfigService.AppConfig = data;
    return data;
  }

  getConfig(): Config {
    if (!ConfigService.AppConfig) {
      const errMsg = 'Config file not loaded.';
      console.log(errMsg);
      throw Error(errMsg);
    }
    return ConfigService.AppConfig;
  }
}

interface Config {
  apiUrl: string;
  googleClientId: string;
  microsoftTenantId: string;
  microsoftClientId: string;
}

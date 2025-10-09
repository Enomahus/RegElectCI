import { defineConfig, devices } from '@playwright/test';

/**
 * See https://playwright.dev/docs/test-configuration
 */
export default defineConfig({
  testDir: './tests',
  // Maximum time one test can run for.
  timeout: 60 * 1000,
  expect: {
    // Maximum time expect() should wait for the condition to be met.
    //For example in `await expect(locator).toHaveText();`
    timeout: 5000,
  },
  // Run all tests in parallel.
  fullyParallel: false,

  // Fail the build on CI if you accidentally left test.only in the source code.
  forbidOnly: !!process.env.CI,

  // Retry on CI only.
  retries: process.env.CI ? 1 : 0,

  // Opt out of parallel tests on CI.
  workers: process.env.CI ? 1 : undefined,

  // Reporter to use. See https://playwright.dev/docs/test-reporters
  reporter: process.env.CI ? [['junit'], ['html', { open: 'never', outputFolder: '' }], ['list']] : 'html',

  // Shared settings for all the project below. See https://playwright.dev/docs/api/class-testoptions
  use: {
    //Maximum time each action such as `click()` can take. Default to 0 (no limit).
    actionTimeout: 0,
    // Base URL to use in actions like `await page.goto('/')`.
    baseURL: process.env.BASE_URL ?? 'http://localhost:3000',

    // Collect trace when retrying the failed test.
    trace: 'on-first-retry',

    screenshot: 'only-on-failure',
  },

  // Configure projects for major browsers.
  projects: [
    {
      name: 'chromium',
      use: {
        ...devices['Desktop Chrome'],
        viewport: { width: 1400, height: 800 },
      },
    },
  ],
  // Run your local dev server before starting the tests.
  webServer: {
    command: 'npm run start',
    url: 'http://localhost:3000',
    reuseExistingServer: !process.env.CI,
  },
});

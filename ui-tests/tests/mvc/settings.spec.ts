import config from './config';
import * as Utils from './utils';

describe('SETTING', () => {
    afterAll(async () => {
        await page.close();
    });

    afterEach(async () => {
        await Utils.wait(1000);
    });

    beforeAll(async () => {
        const login = new Utils.Login(config);
        await login.login();
    });

    describe('CODE FLOW', () => {
        const SETTING_PAGE_RENDER = 'settings.code-flow.page-render';

        /* Step 1 */
        it('should render the page', async () => {
            await Utils.clickMenu('Administration', 'Settings');

            const shot = await Utils.screenshot.test(SETTING_PAGE_RENDER);
            expect(shot).toHaveNoChanges();
        });
    });
});
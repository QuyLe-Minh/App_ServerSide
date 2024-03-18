import config from './config';
import * as Utils from './utils';

describe('WEBHOOKSUBSCRIPTION', () => {
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

    describe('CRUD', () => {
        const WEBHOOKSUBSCRIPTION_CRUD_LIST = 'webhookSubscription.crud.010-list';
        const WEBHOOKSUBSCRIPTION_CRUD_NEW_MODAL = 'webhookSubscription.crud.020-new-modal';
        const WEBHOOKSUBSCRIPTION_CRUD_VALIDATION_SHOW = 'webhookSubscription.crud.030-validation-show';
        const WEBHOOKSUBSCRIPTION_CRUD_VALIDATION_HIDE = 'webhookSubscription.crud.040-validation-hide';
        const WEBHOOKSUBSCRIPTION_CRUD_NEW_SAVE = 'webhookSubscription.crud.050-new-save';
        const WEBHOOKSUBSCRIPTION_CRUD_DETAIL = 'webhookSubscription.crud.070-detail';
        const WEBHOOKSUBSCRIPTION_CRUD_EDIT_MODAL = 'webhookSubscription.crud.080-edit-modal';
        const WEBHOOKSUBSCRIPTION_CRUD_EDIT_SAVE = 'webhookSubscription.crud.090-edit-save';
        const WEBHOOKSUBSCRIPTION_CRUD_DELETE_WARNING = 'webhookSubscription.crud.100-delete-warning';
        const WEBHOOKSUBSCRIPTION_CRUD_DELETE_CANCEL = 'webhookSubscription.crud.110-delete-cancel';
        const WEBHOOKSUBSCRIPTION_CRUD_DELETE_CONFIRM = 'webhookSubscription.crud.120-delete-confirm';

        /* Step 1 */
        it('should render the initial list', async () => {
            await Utils.clickMenu('Administration', 'Webhook Subscriptions');
            await Utils.waitForTableContent();

            const shot = await Utils.screenshot.test(WEBHOOKSUBSCRIPTION_CRUD_LIST);
            expect(shot).toHaveNoChanges();
        });

        /* Step 2 */
        it('should display modal on click to "New" button', async () => {
            await Utils.clickByTextExact('Add New Webhook Subscription');
            await Utils.waitForModal('createOrEditModal');

            const shot = await Utils.screenshot.test(WEBHOOKSUBSCRIPTION_CRUD_NEW_MODAL);
            expect(shot).toHaveNoChanges();
        });

        /* Step 3 */
        it('should show error when form is saved before required inputs are filled', async () => {
            await triggerValidation();

            const shot = await Utils.screenshot.test(WEBHOOKSUBSCRIPTION_CRUD_VALIDATION_SHOW);
            expect(shot).toHaveNoChanges();
        });

        /* Step 4 */
        it('should hide error when form is properly filled', async () => {
            await fillInputsWithValidValues();

            const shot = await Utils.screenshot.test(WEBHOOKSUBSCRIPTION_CRUD_VALIDATION_HIDE);
            expect(shot).toHaveNoChanges();
        });

        /* Step 5 */
        it('should save record when "Save" button is clicked', async () => {
            await Utils.saveForm();
            await Utils.waitForResponse();

            const shot = await Utils.screenshot.test(WEBHOOKSUBSCRIPTION_CRUD_NEW_SAVE);
            expect(shot).toHaveNoChanges();
        });

        /* Step 6 */
        it('should go details page', async () => {
            await Utils.clickButtonByTextWithin('.p-datatable-tbody', 'Details');
            await Utils.waitForResponse();
            await Utils.wait(2000);

            const shot = await Utils.screenshot.test(WEBHOOKSUBSCRIPTION_CRUD_DETAIL);
            expect(shot).toHaveNoChanges();
        });

        /* Step 7 */
        it('should display modal on click to "Edit" button', async () => {
            await clickDropdownBtn('Edit Webhook Subscription');

            await Utils.waitForResponse();
            await Utils.waitForModal('createOrEditModal');

            const shot = await Utils.screenshot.test(WEBHOOKSUBSCRIPTION_CRUD_EDIT_MODAL);
            expect(shot).toHaveNoChanges();
        });

        /* Step 8 */
        it('should save changes to record when "Save" button is clicked', async () => {
            await Utils.fillInputs({ '#WebhookEndpointURL': 'https://www.changedurl.com/' });
            await Utils.saveForm();
            await Utils.waitForResponse();

            const shot = await Utils.screenshot.test(WEBHOOKSUBSCRIPTION_CRUD_EDIT_SAVE);
            expect(shot).toHaveNoChanges();
        });

        /* Step 9 */
        it('should display warning on click to "Disable" button', async () => {
            await clickDropdownBtn('Disable');

            await Utils.waitForConfirmationDialog();

            const shot = await Utils.screenshot.test(WEBHOOKSUBSCRIPTION_CRUD_DELETE_WARNING);
            expect(shot).toHaveNoChanges();
        });

        /* Step 10 */
        it('should not disable record on click to "Cancel" button', async () => {
            await Utils.cancelConfirmation();
            const shot = await Utils.screenshot.test(WEBHOOKSUBSCRIPTION_CRUD_DELETE_CANCEL);
            expect(shot).toHaveNoChanges();
        });

        /* Step 11 */
        it('should disable record on click to "Yes" button', async () => {
            await clickDropdownBtn('Disable');
            await Utils.waitForConfirmationDialog();
            await Utils.confirmConfirmation();
            await Utils.waitForResponse();

            const shot = await Utils.screenshot.test(WEBHOOKSUBSCRIPTION_CRUD_DELETE_CONFIRM);
            expect(shot).toHaveNoChanges();
        });

        async function triggerValidation() {
            await fillInputsWithValidValues();
            await Utils.clearInputs('#WebhookEndpointURL');
        }

        async function fillInputsWithValidValues() {
            await Utils.fillInputs({
                '#WebhookEndpointURL': 'https://www.google.com/',
                'li.p-autocomplete-input-token input': 'App.TestWebhook',
            });

            await page.click('.p-autocomplete-item');
        }

        async function clickDropdownBtn(text: string) {
            await page.click('#dropdownButton01');
            await Utils.wait(500);
            await Utils.clickLinkByTextWithin('#dropdownMenu01', text);
        }
    });
});
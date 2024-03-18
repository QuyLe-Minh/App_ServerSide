import { Screenshot, disableTransitions } from '../../shared';
import config from '../config';

export const screenshot = new Screenshot(config.path);

export async function goto(path: string) {
  await Promise.all([page.goto(config.urlApp + path), page.waitForNavigation()]);
  return disableTransitions();
}

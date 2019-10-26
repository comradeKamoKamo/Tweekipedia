#!/usr/bin/env python
import os, logging
import tweepy

def main():
    api = get_API()
    results = api.search(q="wikipedia.org/wiki/", result_type="recent", count=180)

    for result in results:
        try:
            api.create_favorite(result.id)
        except tweepy.error.RateLimitError:
            # limit
            logging.info("RateLimitError")
            exit();
        except tweepy.error.TweepError as e:
            if e.api_code==139:
                # You have already favorited this status.
                continue
            else:
                logging.error("TweepError:{0}".format(e.api_code))
                exit()

def get_API():
    #OAuth
    api_key = os.environ.get("API_KEY")
    api_secret = os.environ.get("API_SECRET")
    access_token = os.environ.get("ACCESS_TOKEN")
    access_token_secret = os.environ.get("ACCESS_TOKEN_SECRET")
    auth = tweepy.OAuthHandler(api_key,api_secret)
    auth.set_access_token(access_token,access_token_secret)
    api = tweepy.API(auth)
    return api

if __name__=="__main__":
    main()
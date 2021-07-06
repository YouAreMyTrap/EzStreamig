import discord #importamos para conectarnos con el bot
from discord.ext import commands #importamos los comandos
import os
from pathlib import Path
import sys
import glob
bot = commands.Bot(command_prefix='!', description="EzStreaming Bot")
bot.remove_command('help')

@bot.command()
async def start(ctx, arg = ""):
     start_embed = discord.Embed(title="EzStreaming - Start Command", url="https://github.com/YouAreMyTrap/EzStreamig") 
     start_embed.set_author(name="EzStreaming by YouAreMyTrap", url="https://www.paypal.com/biz/fund?id=65SX2HLAZBQWU", icon_url=bot.user.avatar_url) 
     start_embed.set_footer(text="Thx for use EzStreaming if you like program please support the developer")
     start_embed.set_thumbnail(url=bot.user.avatar_url)
     if arg in bot.channels and arg != "":
          start_embed.add_field(name="Start:",value="`" + arg + "`")
          print("Start: "+ arg)
          sys.stdout.flush()
     else:
          start_embed.add_field(name="Start", value='Error: Imposible Start this Channel no exist')
          await ctx.send(embed=start_embed)

@bot.command()    
async def stop(ctx, arg= ""):
     stop_embed = discord.Embed(title="EzStreaming - Stop Command", url="https://github.com/YouAreMyTrap/EzStreamig") 
     stop_embed.set_author(name="EzStreaming by YouAreMyTrap", url="https://www.paypal.com/biz/fund?id=65SX2HLAZBQWU", icon_url=bot.user.avatar_url) 
     stop_embed.set_footer(text="Thx for use EzStreaming if you like program please support the developer")
     stop_embed.set_thumbnail(url=bot.user.avatar_url)
     if arg in bot.channels and arg != "":
          #await ctx.send('Stoped: ' + str(arg))
          stop_embed.add_field(name="Stop:",value="`" + arg + "`")
          print("Stop: "+ arg)
          sys.stdout.flush()
     else:
          stop_embed.add_field(name="Stoped", value='Error: Imposible Stop this Channel no exist')
     await ctx.send(embed=stop_embed)

@bot.command()
async def channels(ctx):
     await ctx.send('Channels: ' + str(bot.channels))
@bot.command()
async def help(ctx):
     help_embed = discord.Embed(title="EzStreaming Help", url="https://github.com/YouAreMyTrap/EzStreamig") 
     help_embed.set_author(name="EzStreaming by YouAreMyTrap", url="https://www.paypal.com/biz/fund?id=65SX2HLAZBQWU", icon_url=bot.user.avatar_url) 
     help_embed.set_thumbnail(url=bot.user.avatar_url)
     help_embed.add_field(name="Start",value="`!start <Channel Name>`")
     help_embed.add_field(name="Stop",value="`!stop <Channel Name>`")
     help_embed.add_field(name="Channels",value="`!channels`")
     help_embed.add_field(name="Discord Server",value="https://discord.gg/YpjxxDVK8x")
     help_embed.set_footer(text="Thx for use EzStreaming if you like program please support the developer")

     await ctx.send(embed=help_embed)
@bot.event
async def on_ready():
    await bot.change_presence(activity=discord.Activity(type=discord.ActivityType.watching, name="You :) !help"))
    bot.channels = [Path(x).stem for x in glob.glob(os.path.abspath(os.path.join(os.path.dirname(sys.executable), os.pardir)) + "/*.bat")]
    print(os.path.dirname(sys.executable))
    print('Started')
    sys.stdout.flush()

bot.run('ODU4NDA2MzkxNzQzNzc0NzIw.YNdrQA.NxEALc7yjJAOrXvsts9XyuPDQYM')
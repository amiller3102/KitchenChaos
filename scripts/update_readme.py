import datetime

# --- CONFIGURATION ---
video_length_str = "10:49:40"
progress_file = "scripts/progress.txt"
readme_file = "README.md"
progress_bar_blocks = 30
start_marker = "<!--progress-start-->"
end_marker = "<!--progress-end-->"
# ----------------------

def time_to_seconds(t):
    h, m, s = map(int, t.split(":"))
    return h * 3600 + m * 60 + s

# Read progress time
with open(progress_file) as f:
    current_time_str = f.read().strip()

# Convert times
video_seconds = time_to_seconds(video_length_str)
current_seconds = time_to_seconds(current_time_str)

# Calculate percentage
percentage = current_seconds / video_seconds
blocks_filled = int(progress_bar_blocks * percentage)
blocks_empty = progress_bar_blocks - blocks_filled
bar = "█" * blocks_filled + "░" * blocks_empty
percent_display = int(percentage * 100)

# Build replacement text
progress_text = f"""
**KitchenChaos Progress**

⏱️ Current Time: {current_time_str}  
🎬 Total Length: {video_length_str}  
📊 Progress: {percent_display}%  

`{bar}`

"""

# Read and update README
with open(readme_file, "r", encoding="utf-8") as f:
    content = f.read()

start = content.find(start_marker)
end = content.find(end_marker)

if start != -1 and end != -1:
    new_content = content[:start+len(start_marker)] + "\n" + progress_text + "\n" + content[end:]
    with open(readme_file, "w", encoding="utf-8") as f:
        f.write(new_content)
else:
    print("Markers not found in README.md")

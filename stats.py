import sys

"""
Input in order:
    bad time
    good time
    bad power
    good power
"""

bad_time = float(sys.argv[1])
bad_power = float(sys.argv[3])
good_time = float(sys.argv[2])
good_power = float(sys.argv[4])

diff_time = bad_time - good_time
diff_power = bad_power - good_power

diff_time_p = (diff_time / bad_time) * 100
diff_power_p = (diff_power / bad_power) * 100

print(f'Bad time: {bad_time}')
print(f'Bad power: {bad_power}')
print(f'Good time: {good_time}')
print(f'Good power: {good_power}')
print(f'Diff time: {diff_time:.2f} ({diff_time_p:.2f}%)')
print(f'Diff power: {diff_power:.2f} ({diff_power_p:.2f}%)')


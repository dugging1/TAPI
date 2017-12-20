using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAPI_Library.Helpers {
	public static class HMath {
		public static int Max(params int[] arr) {
			int highest = arr[0];
			for (int i = 0; i < arr.Length; i++) {
				if (arr[i] > highest) highest = arr[i];
			}
			return highest;
		}

		public static int Min(params int[] arr) {
			int lowest = arr[0];
			for (int i = 0; i < arr.Length; i++) {
				if (arr[i] < lowest) lowest = arr[i];
			}
			return lowest;
		}
	}
}

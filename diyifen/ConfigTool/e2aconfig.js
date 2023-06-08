const path = require("path")
/**
 * @type {import("@ailhc/excel2all").Interfaces}
 */
/**
 * @type {IOutputConfig}
 */
const outConfig = {
    /**单个配置表json输出目录路径 */
    // clientSingleTableJsonDir: path.join(process.cwd(), "__tests__/test-export/jsons"),
    /**合并配置表json文件路径(包含文件名,比如 ./out/bundle.json) */
    clientBundleJsonOutPath: "../../bin/res/zip/lo/tbundle.json",
    /**是否生成声明文件，默认不输出 */
    isGenDts: true,
    /**声明文件输出目录(每个配置表一个声明)，默认不输出 */
    clientDtsOutDir: "../../libs",
    /**
     * 后缀名默认为.d.ts
     */
    bundleDtsFileName: "BAfkTableInterfaces",
    /**是否格式化合并后的json，默认不 */
    // isFormatBundleJson: false,
    /**是否合并所有声明为一个文件,默认true */
    isBundleDts: true,
    /**是否将json格式压缩,默认否,减少json字段名字符,效果较小 */
    isCompress: false,
    /**是否Zip压缩,使用zlib */
    // isZip: false


}
/**
 * @type {ITableConvertConfig}
 */
const config = {
    /**
     * 是否启用缓存
     */
    useCache: true,
    /**
     * 是否启用多线程
     * 建议配置表文件数大于200以上才开启，会更有效
     * 测试数据（配置表文件数100）:
     *
     */
    // useMultiThread: true,
    /**
     * 单个线程解析文件的最大数量,默认5
     */
    // threadParseFileMaxNum: 70,
    outputConfig: outConfig,
    tableFileDir: "E://number"
}
module.exports = config;